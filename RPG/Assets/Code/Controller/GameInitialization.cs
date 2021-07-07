using Code.Interface;

namespace Code.Controller
{
    public class GameInitialization
    {
        public GameInitialization(Controllers controller)
        {
            var eventer = new Eventer();
            var inputController = new InputController(eventer);
            var characterController = new CharacterController(eventer);
            controller.Add(inputController);
            controller.Add(characterController);
        }
    }
}