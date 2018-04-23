using System;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace WinSolution.Module {
    public class Updater : ModuleUpdater {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            using (UnitOfWork uow = new UnitOfWork(Session.DataLayer)) {
                for (int i = 0; i < 5; i++) {
                    Order o = new Order(uow);
                    o.Name = string.Format("Order{0}", i);
                    if (i % 2 == 0){
                        o.SimpleBusinessAction();
                    }
                }
                uow.CommitChanges();
            }
        }
    }
}
