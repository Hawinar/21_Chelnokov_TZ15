using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SaveResults
{
    public static class SaveResults
    {
        public static void Save()
        {
            int limitedCount = 10; // Будет выведен топ-{limitedCount} игроков

            List<ResultItem> results = new List<ResultItem>();

            // Получаем все не пустые PlayerPrefs
            for (int i = 0; i < limitedCount; i++)
            {
                results.Add(new ResultItem() { score = PlayerPrefs.GetInt($"Score_{i}") });
            }

            // Сортировка 1
            results = results.OrderByDescending(x => x.score).ToList();


            // Добавляем результат текущего игрока
            results.Add(new ResultItem() { score = GameManager.Money });

            //Сортировка 2
            results = results.OrderByDescending(x => x.score).ToList();



            // Отсеивание лишних.
            // В ходе сортировки 2 и данного отсеивания,
            // результат игрока может и не попасть в список лидеров, если результат не соответствуюет критериями,
            // например, слишком мало очков набрано.

            for (int i = results.Count - 1; i >= limitedCount; i--)
            {
                results.Remove(results[i]);
            }


            //Занесение в PlayerPrefs
            for (int i = 0; i < results.Count; i++)
            {
                PlayerPrefs.SetInt($"Score_{i}", results[i].score);
            }

        }
        class ResultItem
        {
            public int score { get; set; }
        }
    }
}
