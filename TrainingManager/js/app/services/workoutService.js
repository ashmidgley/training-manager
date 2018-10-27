var WorkoutService = function () {

    var deleteWorkout = function (workoutId, done, fail) {
        $.ajax({
            url: "/api/workouts/" + workoutId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    }

    return {
        deleteWorkout: deleteWorkout
    }
}()