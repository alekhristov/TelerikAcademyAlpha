const container = (() => {
    $(document).ready(homeController.visualizeHomeController());
    const database = databaseFunc();

    return {
        database
    };
})()

