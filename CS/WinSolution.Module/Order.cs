using System;
using System.ComponentModel;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace WinSolution.Module {
    [DefaultClassOptions]
    public class Order : BaseObject {
        public Order(Session session) : base(session) { }
        private string nameCore;
        public string Name {
            get { return nameCore; }
            set { SetPropertyValue("Name", ref nameCore, value); }
        }
        private string descriptionCore;
        public string Description {
            get { return descriptionCore; }
            set { SetPropertyValue("Description", ref descriptionCore, value); }
        }
        [Persistent("Active")]
        private bool activeCore = true;
        [PersistentAlias("activeCore")]
        public bool Active {
            get { return activeCore; }
        }
        [Action]
        public void SimpleBusinessAction() {
            activeCore = !activeCore;
            OnChanged("Active");
        }
    }
}