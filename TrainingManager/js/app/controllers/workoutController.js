var WorkoutController = function (exerciseService) {
    var operation;
    var exerciseId;
    var link;

    var init = function (container) {
        $('.js-remove-exercise').click(removeExercise);
    };

    //Remove exercise (DELETE)
    var removeExercise = function (event) {
        var input = $(event.target);
        link = $(event.target);
        exerciseId = input.attr("data-exercise-id");
        operation = "Removing exercise";

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
                        exerciseService.deleteExercise(exerciseId, done, fail);
                    }
                }
            }
        });
    };

    var done = function () {
        link.parents("tr").find("td").fadeOut(1000, function () {
            $(this).parent().remove();
        });
        console.log(operation + " was successful!");
    };

    var fail = function () {
        console(operation + " failed!");
    };

    return {
        init: init
    };

}(ExerciseService);