using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

    /// <summary>
    /// Gestisce il tracciamento del corpo umano 
    /// </summary>
    public class HumanBodyTracker : MonoBehaviour
    {
        
        //Skeleton effettivo
        private GameObject skeletonEffettivo;

        //I modelli passati i nbase alla "malattia"
        public GameObject leftArm;
        public GameObject leftLeg;
        public GameObject hips;
        public GameObject rightArm;
        public GameObject rightLeg;
        public GameObject Hips_Head_LeftArm; 

        public static Paziente paziente_scelto = SceltaPaziente.paziente_scelto;

       
        public ARHumanBodyManager m_HumanBodyManager;

        /// <summary>
        /// Get/Set ARHumanBodyManager.
        /// </summary>
        public ARHumanBodyManager humanBodyManager
        {
            get { return m_HumanBodyManager; }
            set { m_HumanBodyManager = value; }
        }

        public GameObject skeletonPrefab {
        get { return skeletonEffettivo; }
        set { skeletonEffettivo = value; }
        }

        Dictionary<TrackableId, BoneController> m_SkeletonTracker = new Dictionary<TrackableId, BoneController>();

        /// <summary>
        /// Associa lo skeleton passato a quello effettivo in base a "malattia" del paziente scelto 
        /// </summary>
        void OnEnable()
        {
            Debug.Assert(m_HumanBodyManager != null, "Human body manager is required.");
            if (paziente_scelto.malattia.Count == 1) {
            Debug.Log("Malattia nel count 1: " + paziente_scelto.malattia[0].parteColpita);
                if (paziente_scelto.malattia[0].parteColpita.Equals("LeftArm")) //Braccio Sinistro
                {
                    skeletonEffettivo = leftArm;
                }
                if (paziente_scelto.malattia[0].parteColpita.Equals("Hips")) //Fianchi
                {
                    skeletonEffettivo = hips;
                }
                if (paziente_scelto.malattia[0].parteColpita.Equals("RightLeg")) //Gamba Destra
                {
                    skeletonEffettivo = rightLeg;
                }
                if (paziente_scelto.malattia[0].parteColpita.Equals("LeftLeg")) //Gamba Sinistra
                {
                    skeletonEffettivo = leftLeg;
                }
                if (paziente_scelto.malattia[0].parteColpita.Equals("RightArm")) //Braccio Destro
                {
                    skeletonEffettivo = rightArm;
                }
            } else {
            Debug.Log("Malattia nel count piu id una: " + paziente_scelto.malattia[0].parteColpita);
            Debug.Log("Malattia nel count piu id una: " + paziente_scelto.malattia[1].parteColpita);
            Debug.Log("Malattia nel count piu id una: " + paziente_scelto.malattia[2].parteColpita);

            skeletonEffettivo = Hips_Head_LeftArm; //Skeleton con più malattie
            }


        m_HumanBodyManager.humanBodiesChanged += OnHumanBodiesChanged;
        }

        void OnDisable()
        {
            if (m_HumanBodyManager != null)
                m_HumanBodyManager.humanBodiesChanged -= OnHumanBodiesChanged;
        }

    void OnHumanBodiesChanged(ARHumanBodiesChangedEventArgs eventArgs)
    {
        BoneController boneController;

        foreach (var humanBody in eventArgs.added)
            {
                //Se il corpo non è presnte nel dizionario
                if (!m_SkeletonTracker.TryGetValue(humanBody.trackableId, out boneController))
                {
                    //instanzia lo skeleton 
                    var newSkeletonGO = Instantiate(skeletonEffettivo, humanBody.transform);
                    boneController = newSkeletonGO.GetComponent<BoneController>();

                    //Lo aggiunge al dizionario
                    m_SkeletonTracker.Add(humanBody.trackableId, boneController);

                }

                //Inizializza e sincronizza la posa dello skeleton alla posa effettiva del corpo tracciato
                boneController.InizializzaJoints();
                boneController.SincronizzaPosa(humanBody);
            }

            foreach (var humanBody in eventArgs.updated)
            {
                if (m_SkeletonTracker.TryGetValue(humanBody.trackableId, out boneController))
                {
                    //sincronizza la posa dello skeleton alla posa effettiva del corpo tracciato
                    boneController.SincronizzaPosa(humanBody);
                }
            }

            foreach (var humanBody in eventArgs.removed)
            {

                if (m_SkeletonTracker.TryGetValue(humanBody.trackableId, out boneController))
                {
                    //Distrugge lo skeleton se il corpo non è più tracciato.
                    Destroy(boneController.gameObject);
                    m_SkeletonTracker.Remove(humanBody.trackableId);
                }
            }
    }
}
