using System.ComponentModel;

namespace SistemaDeTarefas.Enums
{
    public enum StatusTask
    {
        [Description("Pending Task")]
        pending = 1,
        [Description("In Progress Task")]
        InProgress = 2,
        [Description("Completed Task")]
        completed = 3, 

    }
}
