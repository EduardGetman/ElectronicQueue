using ElectronicQueue.AdminClient.View.DialogWindow;
using ElectronicQueue.ClientInfrastructure.Commands;
using ElectronicQueue.ClientInfrastructure.Interface;
using ElectronicQueue.ClientInfrastructure.Repositories;
using ElectronicQueue.Core.Application.Models;
using ElectronicQueue.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ElectronicQueue.AdminClient.ViewModel.Pages
{
    public class WorkerManageViewModel : DataEditPageViewModelBase<WorkerModel>
    {
        public ICommand EditAccountCommand { get; }
        public ICommand AddAccountCommand { get; }
        public override string Title => "Сотрудники";

        private IRepository<WorkerModel> _workerRepository;
        private ObservableCollection<WorkerModel> _workers;
        private WorkerModel _selectedWorker;

        public List<string> States => new List<string>(typeof(ServicePointState).GetEnumNames());

        public override ObservableCollection<WorkerModel> DataSource
        {
            get => _workers;
            set => Set(ref _workers, value);
        }
        public WorkerModel SelectedWorker
        {
            get => _selectedWorker;
            set => Set(ref _selectedWorker, value);
        }

        protected override IRepository<WorkerModel> repository => _workerRepository;

        public ICommand NoParametrisedComand { get; }

        public WorkerManageViewModel()
        {
            EditAccountCommand = new NonparameterizedCommand(() => EditAccount(false));
            AddAccountCommand = new NonparameterizedCommand(() => EditAccount(true));
            _workerRepository = new WorkerRepository();
            DataSource = new ObservableCollection<WorkerModel>();
            if (!IsInDesignMode())
            {
                RefreshData();
            }
        }

        private void EditAccount(bool isNewAccount)
        {
            try
            {
                if (!isNewAccount && SelectedWorker is null)
                {
                    throw new Exception("Выберите сотрудника");
                }
                var userName = string.Empty;
                var password = string.Empty;
                bool isSaveClosed = false;
                var dialog = new AccountEditDialogWindow((u, p) => { userName = u; password = p; isSaveClosed = true; },
                                                         isNewAccount ? "Добавить аккаунт" : "Изменить аккаунт",
                                                         isNewAccount ? string.Empty : SelectedWorker.Account.Login);

                dialog.ShowDialog();
                if (isSaveClosed)
                {
                    WorkerModel worker;
                    if (isNewAccount)
                    {
                        worker = new WorkerModel() { Account = new AccountModel() };
                        DataSource.Add(worker);
                    }
                    else
                    {
                        worker = SelectedWorker;
                    }
                    worker.Account.Login = userName;
                    worker.Account.PasswordHash = password;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
    }
}
