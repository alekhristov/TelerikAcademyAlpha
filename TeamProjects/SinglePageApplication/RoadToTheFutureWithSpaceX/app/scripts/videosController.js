const videosController = (() => {
    const visualizeVideosController = () => {
        $('#request').html($(`
            <h2 class="videos-header">Videos</h2>
            <div class="row">
                <div class="col-md-4 cols-style">
                    <div class="videos row">
                        <iframe allowfullscreen="" frameborder="0" height="253" scrolling="no" src="https://www.youtube.com/embed/ujX6CuRELFE?rel=0" width="450"></iframe>
                    </div>
                </div>    
                <div class="col-md-4 cols-style">
                    <div class="videos row">
                        <iframe allowfullscreen="" frameborder="0" height="253" scrolling="no" src="https://www.youtube.com/embed/Ndpxuf-uJHE?rel=0" width="450"></iframe>
                    </div>
                </div>
                <div class="col-md-4 cols-style">
                <div class="videos row">
                    <iframe allowfullscreen="" frameborder="0" height="253" scrolling="no" src="https://www.youtube.com/embed/aBr2kKAHN6M" width="450"></iframe>
                </div>
            </div>
                <h4 class="more-videos"><a href="https://www.youtube.com/spacex">View more SpaceX videos</a><h4>
            </div>
        `));
    }

    return {
        visualizeVideosController
    }
})();
