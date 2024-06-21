using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dialogue
{
    public string[][] text_1;
    public string[][] text_2;
    public Dialogue(string[][] text1, string[][] text2)
    {
        text_1 = text1;
        text_2 = text2;
    }
}
public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;

    private Dictionary<string, Dialogue> localizedTexts;

    void Awake()
    {
        // Ensure this is the only instance of LocalizationManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadLocalizedTexts();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadLocalizedTexts()
    {
        // Initialize the dictionary
        localizedTexts = new Dictionary<string, Dialogue>();

        // Load English phrases
        string[][] englishText1 = new string[][]
        {
            new string[] {
                "Welcome to the Schrödinger\'s Cat Paradox Game!",
                "In this game, you\'ll explore the mysteries of quantum mechanics through the famous thought experiment known as Schrödinger\'s Cat.",
                "Press to start!"
            },
            new string[] {
                "First, let\'s place the cat inside the box. Press on the cat to put it in the box ",
                "The cat is now in the box. Next, we need to add a vial of poison. Press on the the vial of poison to put it in the box.",
                "The vial of poison is now in the box. Now, let's add the Geiger counter, which will detect radiation.Press on the Geiger counter to put it in the box." ,
                "The Geiger counter is in place. Now, let\'s add a tiny bit of radioactive material. Press on the radioactive material to put it in the box.",
                "The Radioactive Material is in place. Finally, let\'s add the hammer. Press on the hammer to put it in the box.",
                "Now, let\'s check the setup in the box. Press on the box."

                },
            new string[]{
                "As you can see the hammer is held by an electromagnet and when the Geiger counter will detect the radiation ",
                "it will release the hammer and it will break the vial of poison and the cat will die.",
                "Now, let\'s close the box and start the experiment."
            },
            new string[]{
                "In quantum mechanics, particles like the radioactive atom can exist in a superposition of states, meaning they can be both decayed and not decayed at the same time until observed.",
                "This superposition extends to the entire system, so the cat is both alive and dead until you open the box and observe the outcome.",
                "So, you, as an observer influence the state of the radioactive atom and thus if the cat is alive or dead.",
                "Let's open the box and see in which state is the cat."
            },

            new string[]{
                "You can try to open the box again to see if cat is alive."
            }
            // Add more scenes as needed
        };
        string[][] englishText2 = new string[][]
        {
            new string[]{
                "As you can see the hammer is held by an electromagnet and when the Geiger counter will detect the radiation ",
                "it will release the hammer and it will break the vial of poison and the cat will die.",
                "Now, let\'s close the box and start the experiment."
            },
             new string[]{
                "Oh, look! The cat is still alive!"
            },
            new string[]{
                "Oh, no! The cat died!"
            },
            // Add more scenes as needed
        };
         localizedTexts["en"] = new Dialogue(englishText1, englishText2);
        // Load Romanian phrases
        string[][] romanianText1 = new string[][]
        {
            new string[] {
                "Bine ați venit la jocul paradoxul Pisicii lui Schrödinger!",
                "În acest joc, veți explora misterele mecanicii cuantice prin celebrul experiment de gândire cunoscut sub numele de Pisica lui Schrödinger.",
                "Apasă pentru a începe!"
            },
            new string[] {
                "Mai întâi, să punem pisica în cutie. Apasă pe pisică pentru a o pune în cutie.",
                "Pisica este acum în cutie. Următorul pas este să adăugăm o fiolă de otravă. Apasă pe fiola de otravă pentru a o pune în cutie.",
                "Fiola de otravă este acum în cutie. Acum, să adăugăm contorul Geiger, care va detecta radiațiile. Apasă pe contorul Geiger pentru a-l pune în cutie.",
                "Contorul Geiger este la locul său. Acum, să adăugăm o cantitate mică de material radioactiv. Apasă pe materialul radioactiv pentru a-l pune în cutie.",
                "Materialul radioactiv este la locul său. În cele din urmă, să adăugăm ciocanul. Apasă pe ciocan pentru a-l pune în cutie.",
                "Acum, să verificăm configurația din cutie. Apasă pe cutie."
            },
            new string[]{
                "După cum puteți vedea, ciocanul este ținut de un electromagnet și când contorul Geiger va detecta radiația, ",
                "va elibera ciocanul și va sparge fiola de otravă, iar pisica va muri.",
                "Acum, să închidem cutia și să începem experimentul."
            },
            new string[]{
                "În mecanica cuantică, particulele precum atomul radioactiv pot exista într-o superpoziție de stări, ceea ce înseamnă că pot fi atât descompuse, cât și nedescompuse în același timp până când nu sunt observate.",
                "Această superpoziție se extinde la întregul sistem, astfel încât pisica este atât vie, cât și moartă până când deschideți cutia și observați rezultatul.",
                "Deci, tu, ca observator, influențezi starea atomului radioactiv și astfel dacă pisica este vie sau moartă.",
                "Să deschidem cutia și să vedem în ce stare se află pisica."
            },
            new string[]{
                "Poți încerca să deschizi din nou cutia pentru a vedea dacă pisica este vie."
            }
            // Add more scenes as needed
        };
        string[][] romanianText2 = new string[][]
        {
            new string[]{
                "După cum puteți vedea, ciocanul este ținut de un electromagnet și când contorul Geiger va detecta radiația ",
                "va elibera ciocanul și va sparge fiola de otravă, iar pisica va muri.",
                "Acum, să închidem cutia și să începem experimentul."
            },
            new string[]{
                "Oh, uite! Pisica este încă în viață!"
            },
            new string[]{
                "Oh, nu! Pisica a murit!"
            },
        };
        localizedTexts["ro"] = new Dialogue(romanianText1, romanianText2);
    }
    public Dialogue GetLocalizedText(string languageCode)
    {
        if (localizedTexts.ContainsKey(languageCode))
        {
            return localizedTexts[languageCode];
        }
        else
        {
            Debug.LogWarning("Localized text not found for language: " + languageCode);
            return null;
        }
    }
}
