"use strict";
/*
    Javascript for all logic within the "Läs & Skrivhjälp" project
*/

(function () {

    //Skapa en modul
    var app = angular.module("App", []);

    //Dataobjekt som låter oss dela information mellan controllers
    app.factory('GameService', function () {
    	var GameService = {
			questionIndex: -1,
			CurrentQuestionID: function () { return this.AllQuestions[this.questionIndex]; },
            Score: -1,
            Name: "",
            AllQuestions: []
        };
        return GameService;
    });

    //Registrera en kontroller
    var CategoryController = function ($scope, $http, GameService) {
    	$scope.input = { asdf: "asdfasd" };
    	$scope.question = { Headline: "hej", ImageSrc: "", Hint: "" };

        $scope.initScript = function () {
            $scope.getCategories();
        };

        //Hämta kategorierna som finns i databasen
        $scope.getCategories = function () {
            $http.get("Home/GetCategories")
            .then(function Success(response) {
                $scope.Categories = response.data.Categories;
            }, function Error(response) {
            	console.log(response);
            });
            return;
        };

        //Hämta en lista på frågor ur en kategori
        $scope.getQuestions = function (cat) {
        	$http.get(cat != null ? "Home/GetQuestions?cat=" + cat : "Home/GetMixedQuestions")
            .then(function Success(response) {
            	$scope.beginGame(response.data.Questions);	//move to next stage
            }, function Error(response) {
                console.log(response);
            });
        	$scope.$apply();
            return;
        };

        $scope.askNextQuestion = function () {
        	//Dölj kategorivals skärmen om detta är första frågan
        	GameService.questionIndex++;
        	$http.get("Home/Question?ID=" + GameService.CurrentQuestionID())
			.then(function Success(response) {
				$scope.question = response.data;
				console.log(response.data);

				
				alert($scope.question.Headline);
			}, function Error(response) {
		   		console.log(response);
			});

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

        $scope.beginGame = function (questions) {
            //Inträffar när man valt en kategori - starta utfrågningen
        	GameService.AllQuestions = questions;
        	GameService.CurrentQuestion = -1;
        	GameService.Score = 0;
        	$scope.askNextQuestion();
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

    //};

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

