const rocketsController = (() => {
    const visualizeRocketsController = () => {
        $.get(config.rocketsApi)
            .then((result) => {
                container.database.rockets = result;

                let rocketsData = '<div><h2 class="rockets-header">SpaceX\'s babies</h2><div class="row">';

                for (rocket of result) {
                    rocketsData += `<div id="${rocket.id}" class="col-md-4 cols-style"><a href="#/rockets/${rocket.id}"><img src="app/images/${rocket.id}.jpg" alt="" class="img-fluid img-hover"></a>`
                    rocketsData += `<h3>Rocket name: ${rocket.name}</h3>`;
                    rocketsData += `<h3>Cost per launch: $${rocket.cost_per_launch}</h3></div>`;
                }
                rocketsData += '</div> </div>';
                $('#request').html(rocketsData);
            });
    }

    return {
        visualizeRocketsController
    }
})();
