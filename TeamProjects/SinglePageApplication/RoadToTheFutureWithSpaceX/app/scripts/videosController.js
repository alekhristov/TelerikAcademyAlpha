const videosController = (() => {
    const visualizeVideosController = () => {
        $('#request').html($(`
            <h2 class="rockets-header">Videos</h2>
            <div class="row">
                <div class="col-md-6 cols-style">
                    <div class="videos row">
                        <iframe allowfullscreen="" frameborder="0" height="253" scrolling="no" src="https://www.youtube.com/embed/ujX6CuRELFE?rel=0" width="450"></iframe>
                    </div>
                </div>    
                <div class="col-md-6 cols-style">
                    <div class="videos row">
                        <iframe allowfullscreen="" frameborder="0" height="253" scrolling="no" src="https://www.youtube.com/embed/Ndpxuf-uJHE?rel=0" width="450"></iframe>
                    </div>
                </div>
            </div>
        `));
    }

    return {
        visualizeVideosController
    }
})();
