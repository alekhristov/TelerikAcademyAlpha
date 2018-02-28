const aboutUsController = (() => {
    const visualizeAboutUs = () => {

        try {
            $('#request').html($(`

            <div class="row">
                <div class="col-md-3 cols-style">
                    <img src="app/images/alekHristov.jpg" alt="" class="img-fluid img-border-aboutus">
                </div>
                <div class="col-md-3 cols-style">
                    <h3><u>Alek Hristov</u></h3>
                    <p class="aboutUs-text">Email: alek.hristov@yahoo.com</p>
                    <p class="aboutUs-text">GitHub profile: <a href="https://github.com/alekhristov">Alek Hristov</a></p>
                </div>
                <div class="col-md-3 cols-style">
                    <img src="app/images/ivanGargov.png" alt="" class="img-fluid img-border-aboutus">
                    </div>
                <div class="col-md-3 cols-style">
                    <h3><u>Ivan Gargov</u></h3>
                    <p class="aboutUs-text">Email: iv.gargov@gmail.com</p>
                    <p class="aboutUs-text">GitHub profile: <a href="https://github.com/igargov">Ivan Gargov</a></p>
                </div>
            </div>
            `));
        }
        catch (error) {
            $('#request')
                .html($(`<h2>An Error has Ocurred</h2>`));
        }
    }
    return {
        visualizeAboutUs
    }
})();