var WorkoutService = function () {

    var deleteWorkout = function(workoutId, done, fail) {
        $.ajax({
                url: "/api/workouts/" + workoutId,
                method: "DELETE"
            })
            .done(done)
            .fail(fail);
    };

    var getExerciseCount = function(workoutId) {
        var result = null;
        $.ajax({
            url: "/api/workouts/exercise-count/" + workoutId,
            type: 'get',
            dataType: 'html',
            async: false,
            success: function (data) {
                result = data;
            }
        });
        return result;
    };

    return {
        deleteWorkout: deleteWorkout,
        getExerciseCount: getExerciseCount
    };
}();