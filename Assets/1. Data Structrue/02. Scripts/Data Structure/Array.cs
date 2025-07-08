using UnityEngine;

public class Array : MonoBehaviour
{
    // 자료형 [] : 정적 배열
    int[] array1; // 배열 선언
    int[] array2 = { 10, 20, 30, 40, 50 }; // 배열 선언과 동시에 초기화
    int[] array3 = new int[5]; // 배열 선언 및 공간 할당
    int[] array4 = new int[5] { 10, 20, 30, 40, 50}; // 배열 선언 및 공간 할당 + 초기화

    NewData[] data = new NewData[5];
    
    // 다차원 배열
    private int[,] marray1 = new int[3, 3];
    private int[,,] marray2 = new int[2, 3, 4]; 
    
    // 가변 배열
    int[][] numbers = new int[3][];
    
    void Start(){
        numbers[0] = new int[2] { 1, 2 };
        numbers[1] = new int[4] { 3, 4, 5, 6 };
        numbers[2] = new int[3] { 7, 8, 9 };
    }
    

}


public class NewData
{
    
}
