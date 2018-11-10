(function () {

    "use strict";

    // Getting existing module
    angular.module("app-plans")
        .controller("plansController", plansController);

    function plansController($scope, $http, $window) {
        var vm = this;
        vm.isBusy = false;
        vm.generalMessage = "";
        vm.errorMessage = "";

        $scope.model = {
            planId: null,
            weeksLength: 0,
            currWeek: 0,
            showWeekLeft: false,
            showWeekRight: false,
            days: [0, 1, 2, 3, 4, 5, 6],
            workouts: [],
            workoutsDict: {},
            showLeft: false,
            showRight: true,
            dayNames: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'],
            dayNamesMobile: ['M', 'T', 'W', 'T', 'F', 'S', 'S']
            //showImageContent: false,
            //imageCanEdit: null,
            //imageHasSrc: null,
        };

        $scope.init = function (planId, weeksLength) {
            $scope.model.weeksLength = weeksLength;
            $scope.model.currWeek = 1;
            $scope.model.planId = planId;
            if (weeksLength > 1) {
                $scope.model.showWeekRight = true;
            }
            $('.js-star-rating').rating({ displayOnly: true, theme: 'krajee-fa' });
            $scope.getWorkouts();
        };
        
        $scope.getWorkouts = function () {
            $http.get("/api/workouts/" + $scope.model.planId)
                .then(function (response) {
                    //success
                    angular.copy(response.data.Workouts, $scope.model.workouts);
                }, function (error) {
                    //error
                    vm.errorMessage = "Failed to get workouts for plan.";
                })
                .finally(function () {
                    //Order workouts in dictionary based on week and day value
                    var i;
                    for (i = 0; i < $scope.model.workouts.length; i++) {
                        $scope.model.workoutsDict[(($scope.model.workouts[i].Week) * 7) + $scope.model.workouts[i].Day] = $scope.model.workouts[i];
                    }
                    vm.isBusy = false;
                });
        };

        $scope.removeWorkout = function (id) {
            bootbox.dialog({
                message: "Are you sure you want to remove this workout?",
                title: "Confirm",
                buttons: {
                    no: {
                        label: "No",
                        className: "btn-default",
                        callback: function () {
                            console.log("Cancelled removal of workout " + id);
                            bootbox.hideAll();
                        }
                    },
                    yes: {
                        label: "Yes",
                        className: "btn-danger",
                        callback: function () {
                            //workoutService.deleteWorkout(workoutId, workoutRemoveDone, workoutRemoveFail);
                            $.ajax({
                                url: "/api/workouts/" + id,
                                method: "DELETE"
                            })
                            .done(workoutRemoveDone)
                            .fail(workoutRemoveFail);
                        }
                    }
                }
            });
        };

        var workoutRemoveDone = function () {
            if ($scope.model.workouts.length > 1 && $scope.model.workoutIndex === 0) {
                $scope.model.workoutIndex++;
                $scope.getWorkouts();
            } else if ($scope.model.workouts.length > 1 && $scope.model.workoutIndex !== 0) {
                $scope.model.workoutIndex--;
                $scope.getWorkouts();
            } else {
                location.reload();
            }
        };

        var workoutRemoveFail = function () {
            console.log("Removal of workout " + $scope.model.selectedWorkout.workoutId + " was unsuccessful :(");
        };

        $scope.shiftWeekLeft = function () {
            //If not first element in workout array, decrement displayed workout by 1
            if ($scope.model.currWeek > 0) {
                $scope.model.currWeek -= 1;
            }
            showArrows();
        };

        $scope.shiftWeekRight = function () {
            //If not last element in workout array, increment displayed workout by 1
            if ($scope.model.currWeek < $scope.model.weeksLength) {
                $scope.model.currWeek += 1;
            }
            showArrows();
        };

        var showArrows = function () {
            var len = $scope.model.workouts.length;
            if ($scope.model.currWeek === 1 && $scope.model.weeksLength > 1) {
                $scope.model.showWeekLeft = false;
                $scope.model.showWeekRight = true;
            } else if ($scope.model.currWeek === $scope.model.weeksLength && $scope.model.weeksLength > 1) {
                $scope.model.showWeekLeft = true;
                $scope.model.showWeekRight = false;
            } else if ($scope.model.weeksLength === 1) {
                $scope.model.showWeekLeft = false;
                $scope.model.showWeekRight = false;
            } else if ($scope.model.weeksLength > 1 && $scope.model.currWeek > 0 && $scope.model.currWeek < $scope.model.weeksLength) {
                $scope.model.showWeekLeft = true;
                $scope.model.showWeekRight = true;
            }
        };

        //$scope.exerciseImageSelected = function (exerciseId) {
        //    $scope.model.exerciseId = exerciseId;
        //    var exercise = {};
        //    var imageSrc;

        //    $http.get("/api/exercises/" + exerciseId)
        //        .then(function (response) {
        //            //success
        //            angular.copy(response.data.Exercise, exercise);
        //        }, function (error) {
        //            //error
        //            vm.errorMessage = "Failed to get exercise image for exercise " + exerciseId;
        //        })
        //        .finally(function () {
        //            vm.isBusy = false;
        //            $scope.model.workoutModalHeader = "Image for " + exercise.Name;
                    
        //            if (exercise.Image !== null) {
        //                $scope.model.imageHasSrc = true;
        //                imageSrc = "data:image/png;base64," + exercise.Image;
        //                $scope.model.modalImageSrc = imageSrc;
        //            } else {
        //                $scope.model.imageHasSrc = false;
        //            }

        //            $scope.model.showWorkoutContent = false;
        //            $scope.model.showImageContent = true;
        //        });
        //};
    }
})();