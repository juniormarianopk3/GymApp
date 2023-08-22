using GymApp.Data;
using GymApp.Models;

namespace GymApp;

public partial class ExercercioDetails : ContentPage {
    private Exercicio _exercicios;
    public ExercercioDetails(IExercicioRepository repository) {

        InitializeComponent();
        OnAppearing();
    }
    public void GetExerciciosToDetails(Exercicio exercicios) {
        _exercicios = exercicios;

        Nome.Text = exercicios.Nome;
        AreaCorporal.Text = exercicios.AreaCorporal;
        ImagemExercicio.Source = exercicios.ImagemExercicio;
        Preparacao.Text = exercicios.Preparacao;
        Execucao.Text = exercicios.Execucao;
        Dicas.Text = exercicios.Dicas;
        ImagemMusculoAlvo.Source = exercicios.ImagemMusculoAlvo;
        MusculoPrincipal.Text = exercicios.MusculoPrincipal;
        MusculoSecundario.Text = exercicios.MusculoSecundario;
    }

    protected override async void OnAppearing() {
        base.OnAppearing();
        await Task.Delay(100);
        ImagemExercicio.IsAnimationPlaying = false;
        await Task.Delay(100);
        ImagemExercicio.IsAnimationPlaying = true;
    }
}