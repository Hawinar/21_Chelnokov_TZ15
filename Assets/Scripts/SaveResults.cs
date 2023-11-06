using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SaveResults
{
    public static class SaveResults
    {
        public static void Save()
        {
            int limitedCount = 10; // ����� ������� ���-{limitedCount} �������

            List<ResultItem> results = new List<ResultItem>();

            // �������� ��� �� ������ PlayerPrefs
            for (int i = 0; i < limitedCount; i++)
            {
                results.Add(new ResultItem() { score = PlayerPrefs.GetInt($"Score_{i}") });
            }

            // ���������� 1
            results = results.OrderByDescending(x => x.score).ToList();


            // ��������� ��������� �������� ������
            results.Add(new ResultItem() { score = GameManager.Money });

            //���������� 2
            results = results.OrderByDescending(x => x.score).ToList();



            // ���������� ������.
            // � ���� ���������� 2 � ������� ����������,
            // ��������� ������ ����� � �� ������� � ������ �������, ���� ��������� �� �������������� ����������,
            // ��������, ������� ���� ����� �������.

            for (int i = results.Count - 1; i >= limitedCount; i--)
            {
                results.Remove(results[i]);
            }


            //��������� � PlayerPrefs
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
