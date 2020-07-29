using UnityEngine;
using UnityEngine.UI;





public class PaodemiaGame : MonoBehaviour
{
    //Paes / Paes por segundo variáveis
    public Text PaesText;
    public Text PaesPorSegText;
    public Text FazerPaoText;
    public double PaoValorClique;
    public double Paes;
    public double PaesPorSeg;

    //Batedeira variáveis
    public Text BatedeiraGanchoText;
    public double BatedeiraGancho;
    public double BatedeiraGanchoCusto;
    public double BatedeiraGanchoPoder;
    public int BatedeiraGanchoNivel;


    //Panificadora variáveis
    public Text PanificadoraText;
    public double Panificadora;
    public double PanificadoraCusto;
    public double PanificadoraPoder;
    public int PanificadoraNivel;

    public void Load()
    {
        //Pão carregar
        Paes = double.Parse(PlayerPrefs.GetString("Paes", "0"));
        PaesPorSeg = double.Parse(PlayerPrefs.GetString("PaesPorSeg", "0"));
        PaoValorClique = double.Parse(PlayerPrefs.GetString("PaoValorClique", "1"));

        //Batedeira carregar
        BatedeiraGanchoCusto = double.Parse(PlayerPrefs.GetString("BatedeiraGanchoCusto", "10"));
        BatedeiraGanchoPoder = double.Parse(PlayerPrefs.GetString("BadeiraGanchoPoder", "1"));
        BatedeiraGanchoNivel = PlayerPrefs.GetInt("BatedeiraGanchoNivel", 1);

        //Panificadora carregar
        PanificadoraCusto = double.Parse(PlayerPrefs.GetString("PanificadoraCusto", "25"));
        PanificadoraPoder = double.Parse(PlayerPrefs.GetString("PanificadoraPoder", "2"));
        PanificadoraNivel = PlayerPrefs.GetInt("PanificadoraNivel", 1);

    }

    public void Save()
    {
        //Pão salvar
        PlayerPrefs.SetString("Paes", Paes.ToString());
        PlayerPrefs.SetString("PaesPorSeg", PaesPorSeg.ToString());
        PlayerPrefs.SetString("PaoValorClique", PaoValorClique.ToString());

        //Batedeira salvar
        PlayerPrefs.SetString("BatedeiraGanchoCusto", BatedeiraGanchoCusto.ToString());
        PlayerPrefs.SetString("BatedeiraGanchoPoder", BatedeiraGanchoPoder.ToString());
        PlayerPrefs.SetInt("BatedeiraGanchoNivel", BatedeiraGanchoNivel);

        //Panificadora salvar
        PlayerPrefs.SetString("PanificadoraCusto", PanificadoraCusto.ToString());
        PlayerPrefs.SetString("PanificadoraPoder", PanificadoraPoder.ToString());
        PlayerPrefs.SetInt("PanificadoraNivel", PanificadoraNivel);

    }

    void Start()
    {
        //Carregar o jogo
        Load();

    }

    void Update()
    {
        //Texto Pão Clique / Pães por segundo
        if (PaoValorClique == 1)
        {
            FazerPaoText.text = "+" + PaoValorClique + " pão";
        } else
        {
            FazerPaoText.text = "+" + PaoValorClique + " pães";
        }

        PaesText.text = "Pães: " + Paes.ToString("F0");
        PaesPorSegText.text = PaesPorSeg.ToString("F0") + " pães/s";

        //Texto Botão Batedeira e Panificadora
        BatedeiraGanchoText.text = "Batedeira com Gancho\n" +
            "Custo: " + BatedeiraGanchoCusto.ToString("F0") + " pães\n" +
            "Poder: +" + BatedeiraGanchoPoder + " Pão por clique\n" +
            "Nível: " + BatedeiraGanchoNivel;
        PanificadoraText.text = "Panificadora\n" +
            "Custo: " + PanificadoraCusto.ToString("F0") + " pães\n" +
            "Poder:  " + PanificadoraPoder + " pães por segundo\n " +
            "Nível: " + PanificadoraNivel;

        //Gerar pão por segundo
        Paes += PaesPorSeg * Time.deltaTime;

        //Salvar o jogo
        Save();
    }

    //Botões

    public void NovoJogo()
    {
        //Pão / Pães por segundo resetar
        Paes = 0;
        PaesPorSeg = 0;
        PaoValorClique = 1;

        //Batedeira resetar
        BatedeiraGanchoCusto = 10;
        BatedeiraGanchoPoder = 1;
        BatedeiraGanchoNivel = 1;

        //Panificadora resetar
        PanificadoraCusto = 25;
        PanificadoraNivel = 1;
        PanificadoraPoder = 2;
    }

    public void SairJogo()
    {
        Application.Quit();
    }

    public void Cheat()
    {
        Paes += 100;
    }

    public void FazerPao() 
    {
        Paes += PaoValorClique;
    }

    public void ComprarBatedeiraGancho ()
    {
        if (Paes >= BatedeiraGanchoCusto)
        {
            Paes -= BatedeiraGanchoCusto;
            BatedeiraGanchoNivel++;
            BatedeiraGanchoCusto *= 1.15;
            PaoValorClique++;
        }
       
    }

    public void ComprarBatedeiraGanchoMaximo()
    {
        while (Paes >= BatedeiraGanchoCusto)
        {
            Paes -= BatedeiraGanchoCusto;
            BatedeiraGanchoNivel++;
            BatedeiraGanchoCusto *= 1.15;
            PaoValorClique++;
        }

    }

    public void ComprarPanificadora()
    {
        if (Paes >= PanificadoraCusto)
        {
            Paes -= PanificadoraCusto;
            PaesPorSeg = PanificadoraPoder;
            PanificadoraPoder++;
            PanificadoraNivel++;
            PanificadoraCusto *= 1.15;
            
        }

    }

    public void ComprarPanificadoraMax()
    {
        while (Paes >= PanificadoraCusto)
        {
            Paes -= PanificadoraCusto;
            PaesPorSeg = PanificadoraPoder;
            PanificadoraPoder++;
            PanificadoraNivel++;
            PanificadoraCusto *= 1.15;

        }

    }
}
