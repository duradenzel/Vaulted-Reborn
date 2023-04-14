// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function UpdateModifier(score) {
    var mod_html = score.parentElement.nextElementSibling.children[0];
    var mod = score.value;

    $.ajax({
        url: '/Character/UpdateModifier',
        data: { score: mod, abilityName: mod_html.name },
        type: 'GET',
        success: function (tuple) {
            mod_html.value = tuple.item1;
            if (mod_html.name == "Wisdommod") {
                document.getElementById('passiveperception').value = tuple.item2;
            }
        },
        error: function () {
            alert('Error setting ability score');
        }
    });
}

function UpdateLevel(lvl) {

    var level = lvl.value;

    $.ajax({
        url: '/Character/UpdateLevel',
        data: { level: level },
        type: 'GET',
        success: function (prof) {
            document.getElementById('proficiencybonus').value = prof;
            //console.log(prof);
        },
        error: function () {
            console.log('Error getting prof bonus');
        }
    });
}