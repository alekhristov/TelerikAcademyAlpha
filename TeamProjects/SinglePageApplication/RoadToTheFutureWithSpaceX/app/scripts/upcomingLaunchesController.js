const launchesController = (() => {
    const visualizeLaunchesController = () => {
        $.get(config.launchesApi)
            .then((result) => {
                let launchesData = '<div class="row"><div class="col-md-12 cols-style margin"><h2 class="launch-header">Are you ready to go on a journey into Space?</h2><img src="app/images/starman.jpg" alt="" class="img-fluid  img-width"><h1 class="launch-slogan">Here is your chance!<br>Here are all upcoming SpaceX launches: </h1></div> ';

                for (launch of result) {
                    launchesData += `<div class="col-md-6 cols-style"><h3>Rocket name: ${launch.flight_number}</h3>`;

                    let date = new Date(launch.launch_date_utc);
                    let gmtIndex = date.toUTCString().indexOf('GMT');
                    let parsedDate = date.toUTCString().substring(0, gmtIndex - 1);

                    launchesData += `<h3>Date: ${parsedDate}</h3>`;
                    launchesData += `<h3>Rocket: ${launch.rocket.rocket_name}</h3>`;
                    launchesData += `<h3>Launch site: ${launch.launch_site.site_name_long}</h3>`;

                    if (launch.details !== null) {
                        launchesData += `<h3>Details: ${launch.details}<h3></div>`;
                    }
                    else {
                        launchesData += `</div>`
                    }
                }
                launchesData += '</div></div>';
                $('#request').html(launchesData);
            })
            .catch(function (error) {
                $('#request')
                    .html($(`<h2>An Error has Ocurred</h2>`));
            });
    }

    return {
        visualizeLaunchesController
    }
})();
