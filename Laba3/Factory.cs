using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba3
{                       
    public class Factory
    {
        /// <summary>
        /// Поле экземпляра 
        /// </summary>
        private static Factory factoryInstance;
        /// <summary>
        /// Поле названия 
        /// </summary>
        private string factoryName;
        /// <summary>
        /// Поле 
        /// </summary>
        private Storage factoryStorage;

        /// <summary>
        /// Событие изменения параметров  или его 
        /// </summary>
        public event EventHandler factoryParametersChanged;

        /// <summary>
        /// Приватный конструктор для реализации паттерна Singletone
        /// </summary>
        private Factory()
        {
            factoryName = "";
            factoryStorage = new Storage();
            factoryStorage.StorageParametersChanged += OnStorageParamsChanged;
        }

        /// <summary>
        /// Текущая  
        /// </summary>
        public int CurrentNumberParts
        {
            get
            {
                return GetInstance().factoryStorage.CurrentSumParts;
            }
            set
            {
                GetInstance().factoryStorage.CurrentSumParts = value;
            }
        }

        /// <summary>
        /// Текущее состояние 
        /// </summary>
        public bool CurrentOpeningStatus
        {
            get
            {
                return GetInstance().factoryStorage.IsFactoryOpen;
            }
            set
            {
                GetInstance().factoryStorage.IsFactoryOpen = value;
            }
        }

        /// <summary>
        /// Название компьютера
        /// </summary>
        public string ourFactoryName
        {
            get
            {
                return GetInstance().factoryName;
            }
            set
            {
                GetInstance().factoryName = value;
                ThrowParamsChanged();
            }
        }

        /// <summary>
        /// Метод получения экземпляра. Нужен для реализации паттерна Singletone
        /// </summary>
        /// <returns>Экземпляр объекта</returns>
        public static Factory GetInstance()
        {
            if (factoryInstance == null)
            {
                factoryInstance = new Factory();
            }
            return factoryInstance;
        }

        /// <summary>
        /// Включить 
        /// </summary>
        public void FactoryOpen()
        {
            GetInstance().factoryStorage.FactoryOpen();
            CurrentOpeningStatus = GetInstance().factoryStorage.IsFactoryOpen;
        }

        /// <summary>
        /// Выключить 
        /// </summary>
        public void FactoryClose()
        {
            GetInstance().factoryStorage.FactoryClose();
            CurrentOpeningStatus = GetInstance().factoryStorage.IsFactoryOpen;
        }

        /// <summary>
        /// Увеличить  
        /// </summary>
        public void NumberPartsUp(int delta)
        {
            GetInstance().factoryStorage.PartsUp(delta);
        }

        /// <summary>
        /// Уменьшить  имеющегося 
        /// </summary>
        public void NumberPartsDown(int delta)
        {
            GetInstance().factoryStorage.PartsDown(delta);
        }

        /// <summary>
        /// Перегрузка метода ToString
        /// </summary>
        public override string ToString()
        {
            return "Название завода: " + GetInstance().factoryName + "\r\nПараметры склада:\r\n" +
                GetInstance().factoryStorage.ToString();
        }

        private static void OnStorageParamsChanged(object sender, EventArgs e)
        {
            GetInstance().ThrowParamsChanged();
        }

        private void ThrowParamsChanged()
        {
            factoryParametersChanged.Invoke(GetInstance(), EventArgs.Empty);
        }
    }
}