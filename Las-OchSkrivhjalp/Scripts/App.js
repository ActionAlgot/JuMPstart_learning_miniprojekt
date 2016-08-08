/*
    Javascript for all logic within the "Läs & Skrivhjälp" project
*/

alert("javascript is working");

(function () {

    //Skapa en modul
    var app = angular.module("App", []);

    var SelectCategoryController = function ($scope) {
        $scope.chosenCategory = 0;
        $scope.getCategoryList = function () {
            //Hämta en lista på alla kategorier + den blandade kategorin
            return alert("not implemented");
        };
        $scope.displayCategories = function () {
            //Visa de hämtade kategorierna på skärmen
            return alert("not implemented");
        };
        $scope.categorySelected = function () {
            //Inträffar när man valt en kategori - starta utfrågningen
            return alert("not implemented");
        };
    };

    var QuestionsController = function ($scope) {
        $scope.Score = 0;   //Håller reda på poängen genom alla frågor

        $scope.getQuestion = function () {
            //Hämta nästa fråga ur ID listan 
            return alert("not implemented");
        };
        $scope.displayQuestion = function () {
            //Visa frågan på skärmen
            return alert("not implemented");
        };

        $scope.postAnswer = function () {
            //Skicka in svaret på en fråga
            return alert("not implemented");
        };

        $scope.displayResult = function () {
            //Visa svaret på frågan och räkna upp poäng om den var rätt
            return alert("not implemented");
        };

        $scope.displayNextButton = function () {
            //Visa en knapp till nästa fråga
            return alert("not implemented");
        };
        $scope.displayAskHighscore = function () {
            //Visa ett fält för namn och en knapp till highscorelistan
            return alert("not implemented");
        };

        $scope.postHighscore = function () {
            //Skicka in namn och highscore till servern
            return alert("not implemented");
        };

    };

    var HighscoreController = function ($scope) {
        $scope.getHighscoreList = function () {
            //Hämtar topplistan för en viss kategori
            return alert("not implemented");
        };
        $scope.displayHighscoreList = function () {
            //Visa topplistan tillsammans med en knapp till början
            return alert("not implemented");
        };
    };

    //Registrera kontrollern i modulen
    //app.controller("SelectCategoryController", ["$scope", SelectCategoryController]);
}());


