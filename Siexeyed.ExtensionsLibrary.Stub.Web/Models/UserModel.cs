namespace Siexeyed.ExtensionsLibrary.Stub.Web.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public Module CurrentModel { get; set; }
        public ModuleStatus Status { get; set; }
    }
    public enum Module
    {
        [System.ComponentModel.Description("<Please Select>")]
        None = 0,
        [System.ComponentModel.Description("Introducing Extension Methods")]
        Intro,
        Advanced,
        Library
    }

    public enum ModuleStatus
    {
        [System.ComponentModel.Description("<Please Select>")]
        None = 0,
        Todo = 1,
        [System.ComponentModel.Description("In Progress")]
        InProgress = 2,
        Complete = 3
    }
}