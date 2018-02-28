(function () {

    let jokesData = function () {
        return $.get(config.jokeApi);
    };

    $('#jokesModal').on('show.bs.modal', function (e) {
        jokesData()
            .done(function (data) {
                $('#replaceText').html($(`
                    <div>
                        <h4>${data.setup}</h4>
                        <h5>${data.punchline}</h5>
                    </div>
                `));
        });
    });
}) ();
