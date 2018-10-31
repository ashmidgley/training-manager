var PlanService = function () {
    
    var deletePlan = function (planId, done, fail) {
        $.ajax({
            url: "/api/plans/" + planId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail)
    }

    return {
        deletePlan: deletePlan
    }
}()