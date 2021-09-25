using Snake.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Controllers {
    public abstract class AbstructController {
        /// <summary>
        /// 场景中的所有实体
        /// </summary>
        protected ICollection<AbstructEntity> _entities;
    }
}
