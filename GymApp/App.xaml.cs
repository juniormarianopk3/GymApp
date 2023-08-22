namespace GymApp;

public partial class App : Application {
    public App(ExercicioList exercicioList) {
        InitializeComponent();

        MainPage = new NavigationPage(exercicioList);
    }
}
