using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba3
{
    public class Storage
    {

        public int testGavriil = 0;


        /// <summary>
        /// Поле текущего состояния
        /// </summary>
        private bool isFactoryOpen;
        /// <summary>
        /// Поле текущего количества
        /// </summary>
        public int currentSumParts;

        public string errorSum = "t";

        public string errorMin = "t";


        public int test;

        private int previousOpeningState;

        /// <summary>
        /// Событие изменения параметров 
        /// </summary>
        public event EventHandler StorageParametersChanged;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Storage()
        {
            this.isFactoryOpen = false;
            this.currentSumParts = 0;
            this.previousOpeningState = 0;
        }

        /// <summary>
        /// Конструктор с параметрами состояния 
        /// </summary>
        public Storage(bool isOn, int brightness)
        {
            this.isFactoryOpen = isOn;
            this.currentSumParts = brightness;
        }

        /// <summary>
        /// Конструктор с параметром 
        /// </summary>
        public Storage(int brightness)
        {
            this.currentSumParts = brightness;
            this.isFactoryOpen = false;
        }



        /// <summary>
        /// Текущее состояние
        /// </summary>
        public bool IsFactoryOpen
        {
            get
            {
                return isFactoryOpen;
            }
            set
            {
                isFactoryOpen = value;
                ThrowParamsChangedEvent();
            }
        }




        /// <summary>
        /// Текущая 
        /// </summary>
        /// <exception cref="ArgumentException">Произошла попытка задать меньше 0</exception>
        public int CurrentSumParts
        {
           
            get { return currentSumParts; }
            set
            {

                currentSumParts = value;

                if (value < 0 || value > 50000)

                {

                    throw new System.ArgumentException();
                }

                ////      currentSumParts = value;

                ThrowParamsChangedEvent();
            }
        }

        /*        public int Storage109()
                {

                    this.test = this.currentSumParts;

                }*/

        public int Result()
        {
            int result = this.currentSumParts;
            return (result);
        }



        /// <summary>
        /// Уменьшить детали
        /// </summary>
        /// <remarks>В случае, если currentBrightness - delta окажется меньше 0, currentBrightness будет присвоено значение 0</remarks>
        /// <param name="delta">Изменение, целое НЕОТРИЦАТЕЛЬНОЕ число</param>
        /// <exception cref="ArgumentException">delta задано отрицательное значение</exception>
        public void PartsDown(int delta)
        {
            if (delta < 0)
            {
                throw new System.ArgumentException();
            }
            if (isFactoryOpen)
            {
                if(currentSumParts - delta < 0)
                {
                    errorMin = "Ошибка! Вы не можете уменьшить деталей больше, чем есть на данный момент";
                }


                else
                {
                    currentSumParts = Math.Max(currentSumParts - delta, 0);
                    ThrowParamsChangedEvent();
                }
            }
        }


        /// <summary>
        /// Увеличить детали.
        /// </summary>
        /// <remarks>В случае, если currentBrightness + delta окажется больше 100, currentBrightness будет присвоено значение 100</remarks>
        /// <param name="delta">Изменение, целое НЕОТРИЦАТЕЛЬНОЕ число</param>
        /// <exception cref="ArgumentException">delta задано отрицательное значение</exception>
        public void PartsUp(int delta)
        {
            if (delta < 0)
            {
                throw new System.ArgumentException();
            }
            if (isFactoryOpen)
            {

                if ((currentSumParts + delta) > 50000)
                {
                     errorSum = "Ошибка! Превышено максимальное количество деталей (50000 шт)";
                  
                }
                else
                {
                  ///  currentSumParts = Math.Min(currentSumParts + delta, 50000);
                    currentSumParts = currentSumParts + delta;
                    ThrowParamsChangedEvent();
                }
            }
        }

        /// <summary>
        /// открыть завод
        /// </summary>
        public void FactoryOpen()
        {
            isFactoryOpen = true;
            currentSumParts = previousOpeningState;
            ThrowParamsChangedEvent();
        }

        /// <summary>
        /// закрыть завод
        /// </summary>
        public void FactoryClose()
        {
            isFactoryOpen = false;
            previousOpeningState = currentSumParts;
//TEST           currentBrightness = 0;
            ThrowParamsChangedEvent();
        }

        /// <summary>
        /// Перегрузка метода ToString
        /// </summary>
  
        public override string ToString()
        {

          
            {

                return "Текущее количество деталей на складе: " + currentSumParts + "/50000;\r\n Склад открыт: " + (isFactoryOpen ? "ДА" : "НЕТ");
            }
            

        }

        private void ThrowParamsChangedEvent()
        {
            StorageParametersChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}