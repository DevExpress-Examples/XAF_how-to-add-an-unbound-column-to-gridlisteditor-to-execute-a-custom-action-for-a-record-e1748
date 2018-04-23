using System;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp;

namespace WinSolution.Module {
    public class Updater : ModuleUpdater {
        public Updater(ObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }

        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            for (int i = 0; i < 5; i++) {
                Order o = ObjectSpace.CreateObject<Order>();
                o.Name = string.Format("Order{0}", i);
                if (i % 2 == 0) {
                    o.SimpleBusinessAction();
                }
            }
        }
    }
}