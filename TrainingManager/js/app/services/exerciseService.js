
var ExerciseService = function () {

    var deleteExercise = function (exerciseId, done, fail) {
        $.ajax({
            url: "/api/exercises/" + exerciseId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    }

    return {
        deleteExercise: deleteExercise
    };
}()