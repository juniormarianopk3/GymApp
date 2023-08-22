using Microsoft.Maui.Controls.PlatformConfiguration;

namespace GymApp;

public partial class ModalExercicioList : ContentPage {
    private List<string> dados = new List<string>
        {
            "Peito",
            "Costas",
            "Biceps",
            "Triceps",
            "Quadriceps",
        };


    public ModalExercicioList() {

        InitializeComponent();

    }

    private async void ButtonFechar_Cliked(object sender, EventArgs e) {
        await Navigation.PopModalAsync();

    }

    private async void FiltrarButton_Clicked(object sender, EventArgs e) {
        List<string> opcoesSelecionadas = new List<string>();
        if (CheckBoxOpcao1.IsChecked)
            opcoesSelecionadas.Add(dados[0]);
        if (CheckBoxOpcao2.IsChecked)
            opcoesSelecionadas.Add(dados[1]);
        if (CheckBoxOpcao3.IsChecked)
            opcoesSelecionadas.Add(dados[2]);
        if (CheckBoxOpcao4.IsChecked)
            opcoesSelecionadas.Add(dados[3]);

        // Aplicar a lógica de filtragem de dados
        List<string> dadosFiltrados = dados.Where(d => opcoesSelecionadas.Contains(d)).ToList();

        var listExercicio = new ExercicioList(dadosFiltrados);


          Application.Current.MainPage = listExercicio;
        // Exibir os resultados (por exemplo, em um ListView)
        // Aqui, você pode implementar a lógica para exibir os dados filtrados em algum lugar da sua interface do usuário.
        // Pode ser um ListView, uma coleção de Cards, etc.
        // Para fins de demonstração, exibiremos uma mensagem com os itens filtrados.
        string mensagem = "Itens filtrados:\n";
        foreach (string item in dadosFiltrados) {
            mensagem += item + "\n";
        }
        await Navigation.PushAsync(listExercicio);
        await Navigation.PopModalAsync();
    
       

    }
}