using System.Collections.Generic;
using UnityEngine;

public class StudyAlgorithm : MonoBehaviour
{
    private List<int> nums = new List<int> { 1, 2, 3 };

    void Start()
    {
        Permute(nums, 0);
    }

    // 순열 생성 함수
    void Permute(List<int> nums, int start)
    {
        if (start == nums.Count)
        {
            Debug.Log(string.Join(", ", nums));
            return;
        }

        for (int i = start; i < nums.Count; i++)
        {
            int temp = nums[start];
            nums[start] = nums[i];
            nums[i] = temp;

            Permute(nums, start + 1);

            // 원상복구 (Backtracking)
            temp = nums[start];
            nums[start] = nums[i];
            nums[i] = temp;
        }
    }
}
