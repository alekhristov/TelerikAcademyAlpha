const homeController = (() => {
    const visualizeHomeController = () => {
        $.get(config.companyInfoApi)
            .then((result) => {
                $('#request').html($(`
                <div>
                <div><img src="app/images/spaceXLogo.png" alt="" class="logo img-fluid"></div>
                <div class="container">
                   <p class="text-style">${result.summary}</p>
                   <h2 class="header"style="text-align:center;">Some random header!</h2>
                   <p class="text-style">"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?"</p>
                </div>
                <div class="row">
                   <div class="col-md-6 cols-style">
                      <img src="app/images/elonMusk.jpg" alt="" class="img-fluid img-border">
                   </div>
                   <div class="col-md-6 cols-style">
                      <h3>CEO: <a href="https://en.wikipedia.org/wiki/Elon_Musk">${result.ceo}</a></h3>
                      <h3>Founder: <a href="https://en.wikipedia.org/wiki/Elon_Musk">${result.founder}</a></h3>
                      <h3>Founded: ${result.founded}</h3>
                   </div>
                   <div class="col-md-6 cols-style">
                      <h3 class="text-end">Employees: ${result.employees}</h3>
                   </div>
                   <div class="col-md-6 cols-style">
                      <img src="app/images/employees.jpg" alt="" class="img-fluid img-border">
                   </div>
                   <div class="col-md-6 cols-style">
                      <img src="app/images/headquarters.jpg" alt="" class="img-fluid img-border">
                   </div>
                   <div class="col-md-6 cols-style">
                      <h3>Vehicles: ${result.vehicles}</h3>
                      <h3><a href="https://www.google.com/maps/place/SpaceX/@33.9213093,-118.3301254,17z/data=!3m1!4b1!4m5!3m4!1s0x80c2b5dee46db32d:0x5589bf4232c10232!8m2!3d33.9213093!4d-118.3279367?hl=bg">Headquarters: <br>Address: ${result.headquarters.address} <br>City: ${result.headquarters.city} <br>State: ${result.headquarters.state}</a></h3>
                   </div>
                </div>
             </div>
        `));
            })
            .catch(function (error) {
                $('#request')
                    .html($(`<h2>An Error has Ocurred</h2>`));
            });
    };

    return {
        visualizeHomeController
    }
})();
