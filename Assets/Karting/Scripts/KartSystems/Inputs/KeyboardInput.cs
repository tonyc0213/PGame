using UnityEngine;

namespace KartGame.KartSystems {

    public class KeyboardInput : BaseInput
    {
        public string TurnInputName = "Horizontal";
        public string AccelerateButtonName = "Accelerate";
        public string BrakeButtonName = "Brake";
        public string BoostButtonName = "Boost";

        public override InputData GenerateInput() {
            return new InputData
            {
                Accelerate = Input.GetAxis("Vertical"),
                Brake = Input.GetButton(BrakeButtonName),
                Boost = Input.GetButton(BoostButtonName),
                TurnInput = Input.GetAxis("Horizontal")
            };
        }
    }
}
