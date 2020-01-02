//Code originally by Vectary
//Modified by SR Runblade 2019

//Import the Vectary viewer API
import { VctrApi } from "https://www.vectary.com/viewer-api/v1/api.js";

//Initialise variables
let vctrApi;
const timeBetweenCameraChange = 5000; //Milliseconds

//Add cameras in scene to array
let cameraArray = [
  document.getElementById("camera0"),
  document.getElementById("camera1"),
  document.getElementById("camera2"),
  document.getElementById("camera3"),
  document.getElementById("camera4"),
  document.getElementById("camera5")
];
console.log('Total cameras: ' + cameraArray.length);

let switchingInProgress = false;

//Timed triggers (ie. change camera view over time, looped)
let eventTimedTrigger = new Event("timedTrigger");
var cameraNumber = 0;

//Prepare cameras to switch
function addListeners() {
    camera0.addEventListener("timedTrigger", async _event => {
        if (!switchingInProgress) {
            switchingInProgress = true;
            await vctrApi.switchView("Camera_Overview"); //Note named cameras
            switchingInProgress = false;
        }
    });
    camera1.addEventListener("timedTrigger", async _event => {
        if (!switchingInProgress) {
            switchingInProgress = true;
            await vctrApi.switchView("Camera_1"); //Note named cameras
            switchingInProgress = false;
        }
    });
    camera2.addEventListener("timedTrigger", async _event => {
        if (!switchingInProgress) {
            switchingInProgress = true;
            await vctrApi.switchView("Camera_2"); //Note named cameras
            switchingInProgress = false;
        }
    });
  camera3.addEventListener("timedTrigger", async _event => {
        if (!switchingInProgress) {
            switchingInProgress = true;
            await vctrApi.switchView("Camera_3"); //Note named cameras
            switchingInProgress = false;
        }
    });
  camera4.addEventListener("timedTrigger", async _event => {
        if (!switchingInProgress) {
            switchingInProgress = true;
            await vctrApi.switchView("Camera_4"); //Note named cameras
            switchingInProgress = false;
        }
    });
  camera5.addEventListener("timedTrigger", async _event => {
        if (!switchingInProgress) {
            switchingInProgress = true;
            await vctrApi.switchView("Camera_5"); //Note named cameras
            switchingInProgress = false;
        }
    });
}

async function run() {
    console.log("Example script running..");

    function errHandler(err) {
        console.log("API error", err);
    }

    async function onReady() {
        console.log("API ready..");
        //Set up loop function to change cameras
        setInterval(function() {
            //Change camera "counter"
            if(cameraNumber < cameraArray.length-1) 
                { ++cameraNumber;   }
            else 
                { cameraNumber = 0; }
            //Trigger camera switch
            cameraArray[cameraNumber].dispatchEvent(eventTimedTrigger);
        }, timeBetweenCameraChange)
    }

    vctrApi = new VctrApi("glContainer", errHandler);
    try {
        await vctrApi.init();
    } catch (e) {
        errHandler(e);
    }
  
    //const allSceneCameras = await vctrApi.getCameras();
    //console.log("Cameras", allSceneCameras);

    addListeners();
    onReady();
}

//---------JAVASCRIPT "MAIN()"---------------//
run();
//-------------------------------------------//