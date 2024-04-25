## Chapter 2. 프로그래밍 기초 개인과제 (스파르타 던전 (Text 게임) 만들기)
![image](https://github.com/hayoungbin/TestProject/assets/167050593/33788945-bbfe-4da4-a3b1-c784123ae28c)

## 프로젝트 소개
이번에 개인 과제로 콘솔 게임을 제작하여 만들게 되었습니다.

과제의 존재를 어제(4월 24일 수요일) 알게 되어서 꽤 늦게 시작한 점 죄송하게 생각합니다.

그래도 이틀간 최대한 필수 구현사항만 구현하는 식으로 완성하게 되었습니다.

## 프로젝트를 진행하면서 염두에 둔 점
 - 가장 우선적으로 미니프로젝트때 알게된 사실로 함수를 잘 활용하면 코드를 깔끔하게 만들 수 있다. 라는 사실을 알게되었습니다.
 - 그런 이유에서 함수를 최대한 활용해서 코드를 깔끔하게 볼 수 있게 만드는 연습을 한다고 생각하고 그런 부분을 생각하며 작업했습니다.
 - 그럼에도 아직 모르는 부분이 많아 적용하지 못한 점, 그리고 시간이 얼마 남지않아서 제대로 생각해보지 못한 점이 많아 넘긴 것이 많아서 조금 아쉽습니다.

## 게임 구조와 진행도
wireframe 파일로 별첨해두었습니다.

## 화면별 설명
### 메인 화면
![image](https://github.com/hayoungbin/TestProject/assets/167050593/5d49f704-a069-4f44-8e7e-af8016e98f1a)

메인 화면입니다.

일단 모든 화면들을 함수로 만들어서 구현해보았고 while문 최상단에 두어 반드시 돌아오게 했습니다.

모든 화면의 선택지들은 swihch case로 구현했고, 잘못된 입력을 할 경우 재귀호출을 사용하여 현재 화면을 다시 불러오게 만들었습니다.

그리고 강의 과제를 하다가 알게된 Thread.Sleep()를 이용해서 메세지가 잠시동안 나타났다가 사라지는 것을 나타내보았습니다. 


### 상태 보기
![image](https://github.com/hayoungbin/TestProject/assets/167050593/0d479363-137c-4041-8b9b-d2adbf1ae6cc)
![image](https://github.com/hayoungbin/TestProject/assets/167050593/0a670fc8-6156-4fc4-8c51-192ea4211752)


상태창입니다.

선택지에는 제일 처음으로 올라와있지만 장비를 장착하면 능력치가 변하는 기능이 있기에 구현은 가장 마지막에 했습니다.

반영되는 능력치는 Items 구조체의 값중 0으로 된 값이 무엇인지에 따라 방어력에 가산할지 공격력에 가산할지 정하는 함수를 만들었습니다.

### 인벤토리
![image](https://github.com/hayoungbin/TestProject/assets/167050593/93e5621c-7d53-480b-972b-bcaaf8225abe)
![image](https://github.com/hayoungbin/TestProject/assets/167050593/aeb9108f-f3e1-43a3-88d1-1a5e30ff6911)


인벤토리 창입니다.

아이템과 상점을 구현하고 두번째로 구현하였습니다.

item.notUse의 bool값을 이용하여 아이템의 장착여부를 구현했습니다.

### 상점
![image](https://github.com/hayoungbin/TestProject/assets/167050593/418680ea-d425-4f55-87a2-38d446d3a14d)

![image](https://github.com/hayoungbin/TestProject/assets/167050593/e7d19df6-8ae0-434f-ae51-18f7ef273afc)

상점 창입니다.

가장 먼저 구현한 화면입니다.

```cs
<C#>
        static void BuyItem(Items[] item, int num, int[] gold)
        {
            if (item[num - 1].notHave)
            {
                if (gold[0] >= item[num - 1].value)
                {
                    item[num - 1].notHave = false;
                    int leftGold = gold[0] - item[num - 1].value;
                    gold[0] = leftGold;
                    NowBuyMessage();
                    ShopBuy(gold, item);
                }
                else
                {
                    NotMoneyMessage();
                    ShopBuy(gold, item);
                }
            }
            else
            {
                IsBuyMessage();
                ShopBuy(gold, item);
            }
        }
}
```
위와 같은 함수를 swihch case에 넣어서 아이템 구매를 구현했습니다.

원래는 이 if문과 유사한 구조체 정보들을 하나하나 불러와서 그걸 또 하나하나 case에 넣어서 구현했지만 도중에 구조체 배열을 매개변수에 넣을 수 있다는 것을 깨닫아서 

구조체 배열을 만드는 것부터 처음부터 다시 작업한 결과 만들 수 있게 되었습니다.

그 과정에서 
```cs
<C#>
        static void Print(Items[] item, int num)
        {
            if (item[num].weaponAtk == 0)
            {
                Console.Write($"{item[num].itemName}  |  {item[num].lore}  |  방어력 + {item[num].armorDef}  |");
            }
            else
            {
                Console.Write($"{item[num].itemName}  |  {item[num].lore}  |  공격력 + {item[num].weaponAtk} |");
            }
        }

        static void PrintToShop(Items[] item, int num)
        {
            Console.Write("   {0}.",num + 1);
            Print(item, num);
            if (item[num].notHave)
            {
                Console.WriteLine($"  {item[num].value} G");
            }
            else
            {
                Console.WriteLine("  [구매 완료]");
            }
        }
```
이와 같은 함수도 만들게 되어 for문으로 반복하게 함으로 결과적으로 구매 버튼의 기능을 과 아이템의 목록을 뽑기 위해 있었던 수많은 줄들을 생략하게 되었습니다.

그리고 이 함수들은 조금씩 변형해서 이전 화면들을 구현하는 것에 유용하게 써먹었습니다.

## 마치며
시간에 맞춰 필수기능은 모두 구현하는데 성공했지만 결국 이번에도 시간이 부족하여 여러 추가 기능들을 구현해보지 못했습니다.

그 외에도 뭔가 또 줄일 수 있을것 같은 것들도 많았으나 결국 마지막으로 상태창을 구현할 때는 시간에 쫒기느라 깇게 생각하지 못한 점이 조금 아쉽습니다.

그에 대해선 과제에 대해 정확히 확인하지 못한 제 잘못이니 할 말이 없습니다.
