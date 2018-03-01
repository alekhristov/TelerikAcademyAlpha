const homeController = (() => {
    const visualizeHomeController = () => {
        $.get(config.companyInfoApi)
            .then((result) => {
                $('#request').html($(`
                <div>
                <div><img src="app/images/spaceXLogo.png" alt="" class="logo img-fluid"></div>
                <div class="container">
                   <p class="text-style">${result.summary}</p>
                   <h2 class="header"style="text-align:center;">MAKING HISTORY</h2>
                   <p class="text-style">"SpaceX has gained worldwide attention for a series of historic milestones. It is the only private company ever to return a spacecraft from low-Earth orbit, which it first accomplished in December 2010. The company made history again in May 2012 when its Dragon spacecraft delivered cargo to and from the International Space Station — a challenging feat previously accomplished only by governments. Since then Dragon has delivered cargo to and from the space station multiple times, providing regular cargo resupply missions for NASA. </br>In 2017, SpaceX successfully achieved the first reflight of an orbital class rocket – a historic milestone on the road to full and rapid rocket reusability.</p>
                   <p class="text-style">In 2017, SpaceX successfully achieved the first reflight of an orbital class rocket – a historic milestone on the road to full and rapid rocket reusability.</p>
                   <p class="text-style">In 2018, most powerful operational rocket in the world 'Falcon Heavy' successfully lifted off."</p>
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
