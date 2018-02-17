(function () {

    "use strict";

    // Getting existing module
    angular.module("app-plans")
        .controller("plansController", plansController);

    function plansController($scope, $http) {
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
            selectedWorkout: null,
            workoutIndex: 0,
            showLeft: false,
            showRight: true,
            workoutModalHeader: "",
            exerciseId: null,
            showWorkoutContent: true,
            showImageContent: false,
            imageCanEdit: null,
            imageHasSrc: null,
            modalImageSrc: null,
            showCommentContent: false,
            commentText: "",
            commentCanEdit: null
        };

        $scope.init = function (planId, weeksLength) {
            $scope.model.weeksLength = weeksLength;
            $scope.model.currWeek = 1;
            $scope.model.planId = planId;
            if (weeksLength > 1) {
                $scope.model.showWeekRight = true;
            }

            initSelectedWorkoutModal();
            $('.js-star-rating').rating({ displayOnly: true });
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

        $scope.addExercise = function (workoutId) {
            //Redirect to add exercise page, passing in plan ID and workout ID
            $http({
                url: '/Genre/Get',
                params: {
                    genrename: $routeParams.genrename
                },
                method: 'get'
            }).then(function (response) {
                $scope.list = JSON.parse(response.data);
            });
        };

        $scope.removeExercise = function (exerciseId) {
            $scope.model.exerciseId = exerciseId;
            bootbox.dialog({
                message: "Are you sure you want to remove this exercise?",
                title: "Confirm",
                buttons: {
                    no: {
                        label: "No",
                        className: "btn-default",
                        callback: function () {
                            console.log("Cancelled removal of exercise " + exerciseId);
                            bootbox.hideAll();
                        }
                    },
                    yes: {
                        label: "Yes",
                        className: "btn-danger",
                        callback: function () {
                            $.ajax({
                                url: "/api/exercises/" + exerciseId,
                                method: "DELETE"
                            })
                            .done(exerciseRemoveDone)
                            .fail(exerciseRemoveFail);
                        }
                    }
                }
            });
        };

        var exerciseRemoveDone = function () {
            console.log("Removal of exercise " + $scope.model.exerciseId + " was successful.");
            $scope.getWorkouts();
        };

        var exerciseRemoveFail = function () {
            console.log("Removal of exercise " + $scope.model.exerciseId + " was unsuccessful :(");
        };

        $scope.shiftWeekLeft = function () {
            //If not first element in workout array, decrement displayed workout by 1
            console.log("Shift left clicked");
            if ($scope.model.currWeek > 0) {
                $scope.model.currWeek -= 1;
            }
            showArrows();
        };

        $scope.shiftWeekRight = function () {
            //If not last element in workout array, increment displayed workout by 1
            console.log("Shift right clicked");
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

        $scope.exerciseImageSelected = function (exerciseId) {
            $scope.model.exerciseId = exerciseId;
            var exercise = {};
            var canEdit;
            var imageSrc;

            $http.get("/api/exercises/" + exerciseId)
                 .then(function (response) {
                     //success
                     angular.copy(response.data.Exercise, exercise);
                     canEdit = response.data.CanEdit;
                 }, function (error) {
                     //error
                     vm.errorMessage = "Failed to get exercise image for exercise " + exerciseId;
                 })
                 .finally(function () {
                     vm.isBusy = false;
                     $scope.model.workoutModalHeader = "Image for " + exercise.Name;

                     if (canEdit) {
                         $scope.model.imageCanEdit = true;
                         if (exercise.Image !== null) {
                             $scope.model.imageHasSrc = true;
                             imageSrc = "data:image/png;base64," + exercise.Image;
                             $scope.model.imageCanEdit = true;
                             $scope.model.modalImageSrc = imageSrc;
                         } else {
                             $scope.model.imageHasSrc = false;
                         }
                     } else {
                         $scope.model.imageCanEdit = false;
                         if (exercise.Image !== null) {
                             $scope.model.imageHasSrc = true;
                             imageSrc = "data:image/png;base64," + exercise.Image;
                             $scope.model.modalImageSrc = imageSrc;
                         } else {
                             $scope.model.imageHasSrc = false;
                         }
                     }
                     $scope.model.showWorkoutContent = false;
                     $scope.model.showImageContent = true;
                 });
        };

        $scope.updateExerciseImage = function () {
            var imageInput = document.getElementById("imageUpload");

            if (imageInput.files.length === 1) {
                var blobFile = imageInput.files[0];
                var formData = new FormData();
                formData.append("imageUpload", blobFile);

                $.ajax({
                    url: "../../api/exercises/" + $scope.model.exerciseId,
                    type: "POST",
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function (response) {
                        console.log('Image upload complete for exercise ' + $scope.model.exerciseId + '.');
                        $scope.resetModalVariables();
                        imageInput.value = null;
                    },
                    error: function (jqXHR, textStatus, errorMessage) {
                        console.log(errorMessage);
                    }
                });

                //Update img element
                var exercise = {};
                $http.get("/api/exercises/" + $scope.model.exerciseId)
                 .then(function (response) {
                     //success
                     angular.copy(response.data.Exercise, exercise);
                 }, function (error) {
                     //error
                     vm.errorMessage = "Failed to get exercise image for exercise " + $scope.model.exerciseId;
                 })
                 .finally(function () {
                     var imageSrc = "data:image/png;base64," + exercise.Image;
                     $scope.model.modalImageSrc = imageSrc;
                 });
            } else {
                console.log('ERROR: Image update selected but single file not selected to upload');
            }
        }

        $scope.exerciseCommentSelected = function (exerciseId) {
            $scope.model.exerciseId = exerciseId;
            var exercise = {};
            var canEdit;

            $http.get("/api/exercises/" + exerciseId)
                 .then(function (response) {
                     //success
                     angular.copy(response.data.Exercise, exercise);
                     canEdit = response.data.CanEdit;
                 }, function (error) {
                     //error
                     vm.errorMessage = "Failed to get exercise comment for exercise " + exerciseId;
                 })
                 .finally(function () {
                     vm.isBusy = false;

                     if (canEdit) {
                         $scope.model.commentCanEdit = true;
                         var defaultStr = '';
                         var title = ' Comment';
                         if (exercise.Comment !== null) {
                             defaultStr = exercise.Comment;
                             title = 'Edit' + title;
                         } else {
                             title = 'Enter' + title;
                         }
                         $scope.model.workoutModalHeader = title;
                         $scope.model.commentText = defaultStr;
                     } else {
                         $scope.model.commentCanEdit = false;
                         if (exercise.Comment !== null) {
                             $scope.model.commentText = exercise.Comment;
                         } else {
                             $scope.model.commentText = "No comment for exercise.";
                         }
                     }
                     $scope.model.showWorkoutContent = false;
                     $scope.model.showCommentContent = true;
                 });
        };

        $scope.updateExerciseComment = function () {
            //var comment = $('textarea#comment').val();
            var exercise = {};
            $http.get("/api/exercises/" + $scope.model.exerciseId)
                 .then(function (response) {
                     //success
                     angular.copy(response.data.Exercise, exercise);
                     canEdit = response.data.CanEdit;
                 }, function (error) {
                     //error
                     vm.errorMessage = "Failed to get exercise comment for exercise " + exerciseId;
                 })
                .finally(function () {
                    vm.isBusy = false;
                    exercise.Comment = $scope.model.commentText;
                    console.log(exercise);
                });

            //$http.put("/api/exercises/" + $scope.model.exerciseId, {}, { params: { comment: comment }})
            $http.put("/api/exercises", exercise)
                    .then(function (response) {
                        //success   
                        console.log("Comment updated for exercise " + $scope.model.exerciseId);
                    }, function (error) {
                        //error
                        vm.errorMessage = "Failed to get exercise comment for exercise " + $scope.model.exerciseId;
                    })
                .finally(function () {
                    vm.isBusy = false;
                });
        };

        $scope.resetModalVariables = function () {
            $scope.model.workoutModalHeader = $scope.model.selectedWorkout.Name;
            $scope.model.showWorkoutContent = true;
            $scope.model.showImageContent = false;
            $scope.model.showCommentContent = false;
        }

        // -------------------------------------------------------
        // Called on initialisation to set the hide/show actions for the selected workout modal
        // -------------------------------------------------------
        var initSelectedWorkoutModal = function () {
            // wire up the OK button to dismiss the modal when shown
            $("#selectedWorkoutModal").on("show", function () {
                $("#selectedWorkoutModal a.btn").on("click", function (e) {
                    // dismiss the dialog
                    $("#selectedWorkoutModal").modal('hide');
                });
            });

            // remove the event listeners when the dialog is dismissed
            $("#selectedWorkoutModal").on("hide", function () {
                $("#selectedWorkoutModal a.btn").off("click");
            });

            // remove the actual elements from the DOM when fully hidden
            $("#selectedWorkoutModal").on("hidden", function () {
                $("#selectedWorkoutModal").remove();
            });
        }

        // -------------------------------------------------------
        // Called to display the selected workout
        // -------------------------------------------------------
        $scope.showSelectedWorkoutModal = function (workoutIndex) {
            $scope.model.workoutModalHeader = $scope.model.workoutsDict[workoutIndex].Name;
            $scope.model.workoutIndex = workoutIndex;
            $scope.model.selectedWorkout = $scope.model.workoutsDict[workoutIndex];
            // wire up the actual modal functionality and show the dialog
            $("#selectedWorkoutModal").modal({
                "backdrop": "static",
                "keyboard": true,
                "show": true
            });
            $("#selectedWorkoutModal").show();
        }

        // -------------------------------------------------------
        // Called to hide the selected workout modal from the page
        // -------------------------------------------------------
        var removeSelectedWorkoutModal = function () {
            $("#selectedWorkoutModal").hide();
            $scope.resetModalVariables();
        }
    }
})();