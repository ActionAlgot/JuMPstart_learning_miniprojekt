/*
    Javascript for all logic within the "Läs & Skrivhjälp" project
*/

(function () {

    //Skapa en modul
    var app = angular.module("App", []);

    //Dataobjekt som låter oss dela information mellan controllers
    app.factory('GameService', function () {
        var GameService = {
            CurrentQuestion: 0,
            Score: 0,
            Name: "",
            AllQuestions: { }
        };
        return GameService;
    });

    //Registrera en kontroller
    var CategoryController = function ($scope, $http, GameService) {
        $scope.selectedMixedQuestions = false;
        $scope.selectedCategory = null;

        $scope.initScript = function () {
            $scope.getCategories();
        };

        //Hämta kategorierna som finns i databasen
        $scope.getCategories = function () {
            $scope.selectedCategory = false;
            $scope.selectedMixedQuestions = null;
            $http.get("Home/GetCategories")
            .then(function Success(response) {
                $scope.Categories = response.data.Categories;
            }, function Error(response) {
                alert("Fick inga kategorier från servern.");
            });
            return;
        };

        //Hämta en lista på frågor ur en kategori
        $scope.getQuestions = function (cat) {
            $scope.selectedCategory = cat;
            $scope.selectedMixedQuestions = false;
            //Hämta objektet som innehåller frågor att ställa
            //och gå till frågeloopen
            $http.get("Home/GetQuestions?cat=" + cat)
            .then(function Success(response) {
                GameService.AllQuestions = response.data.Questions;
                $scope.categorySelected();
            }, function Error(response) {
                console.log(response);
            });
            return;
        };

        //Hämta en lista på blandade frågor
        $scope.getMixedQuestions = function () {
            $scope.selectedMixedQuestions = true;
            $scope.selectedCategory = null;

            //Hämta objektet som innehåller frågor att ställa
            //och gå till frågeloopen
            $http.get("Home/GetMixedQuestions")
            .then(function Success(response) {
                GameService.AllQuestions = response.data.Questions;
                $scope.categorySelected();
            }, function Error(response) {
                console.log(response);
            });
            return;
        };

        $scope.askNextQuestion = function () {
            //Dölj kategorivals skärmen om detta är första frågan
            
            //Visa nästa fråga

                //Fyll i fälten i templaten
        };

        $scope.answerQuestion = function () {
            //Kontakta servern för att se om svaret var rätt 
            //och vilken poäng iv fick
            
            //Uppdatera status på vilken fråga vi är på och vilken poäng vi har

            //Hoppa till nästa fråga - askNextQuestion
            //eller visa skärm för att ange namn
        };
        
        $scope.EnteredName = function () {
            //Spara namn till db med score

            //Visa highscore sida
        };
        
        ////Switcha till skärmen för val av kategori för ett nytt spel
        //$scope.displayCategories = function () {
        //    return alert("not implemented");
        //};

        $scope.categorySelected = function () {
            //Inträffar när man valt en kategori - starta utfrågningen
            console.log(GameService.AllQuestions);
            //return alert("Dags att börja utfrågningen");
            $scope.$emit('StartGame');
        };
        $scope.initScript();
    };

    //Registrera kontrollern i modulen
    app.controller("CategoryController", ["$scope", "$http", "GameService", CategoryController]);

    //var QuestionsController = function ($scope, $http, GameService) {
    //    $scope.Score = 0;   //Håller reda på poängen genom alla frågor

        //$scope.$on('StartGame', function(event) {
        //    alert("Hello from the QuestionsController");
        //});
        
        //    $scope.getQuestion = function () {
    //        //Hämta nästa fråga ur ID listan
    //        return alert("not implemented");
    //    };
    //    $scope.displayQuestion = function () {
    //        //Visa frågan på skärmen
    //        return alert("not implemented");
    //    };

    //    $scope.postAnswer = function () {
    //        //Skicka in svaret på en fråga
    //        return alert("not implemented");
    //    };

    //    $scope.displayResult = function () {
    //        //Visa svaret på frågan och räkna upp poäng om den var rätt
    //        return alert("not implemented");
    //    };

    //    $scope.displayNextButton = function () {
    //        //Visa en knapp till nästa fråga
    //        return alert("not implemented");
    //    };
    //    $scope.displayAskHighscore = function () {
    //        //Visa ett fält för namn och en knapp till highscorelistan
    //        return alert("not implemented");
    //    };

    //    $scope.postHighscore = function () {
    //        //Skicka in namn och highscore till servern
    //        return alert("not implemented");
    //    };

    };

    //Registrera kontrollern i modulen
    //app.controller("QuestionsController", ["$scope", "$http", "GameService", QuestionsController]);


    //var HighscoreController = function ($scope) {
    //    $scope.getHighscoreList = function () {
    //        //Hämtar topplistan för en viss kategori
    //        return alert("not implemented");
    //    };
    //    $scope.displayHighscoreList = function () {
    //        //Visa topplistan tillsammans med en knapp till början
    //        return alert("not implemented");
    //    };
    //};

    //Registrera kontrollern i modulen
    //app.controller("SelectCategoryController", ["$scope", SelectCategoryController]);
}());

