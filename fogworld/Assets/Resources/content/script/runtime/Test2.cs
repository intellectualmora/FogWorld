using System.Collections;
using System.Collections.Generic;
using Backend;
using UnityEngine;

public class Test2 : MonoBehaviour
{// ����, ����,������ ��֪����Ӧ�����������ߣ���������ʶ����ֳ�����ָ������������Զ��Ǽӷ�ԭ����ʶ��ֳ����ȡ��Сֵ����������λ�������㡣
    /* ƽ�����ࣺ �������У�20����Ů��22������������λ���㣩������ 20����֪ 20����Ӧ 20������ ���У�20 ��Ů��16������ 20������ 20����ʶ 20���ָ��� 20����ֳ�� 20
     * �������ٻ����������£�
     * 1. �ⲿ���٣��۾�������+1����֪+8��*2�����ӣ�����+2������ͣ�����+2������������+1����֪+2��*2,ͷ������+4������+2������׵������+5����Ӧ+10�����أ�����+2������+4������������+1������+3�����ۣ�����+1������+4������+5/4����Ӧ+2��*2���ȣ�����+1������+4������+5/4����Ӧ+3��*2, ���鷿������+2��������������+1����ֳ��+20����غ�裨��ֳ��+20������������ֳ��+20����
     * 2. �ڲ����٣�ѪҺ������λ�á�����ʶ 20���ָ��� 10�����ԡ�ͷ��������+20����ʶ 20�������ࡾ�ء�����ʶ 20���ָ��� 6������������������+5��*2���Ρ��ء�����ʶ 20���ָ��� 2��*2��θ������������+6����С��������(����+10)���󳦡�����(����+4)���Ρ�����������+10�������ӹ�����������ֳ��+20����
     * �����ж�����ʶ=0
     * ʧ���ж���0<��ʶ<4�����ʣ� �� ��ʶ��������������Ӧ<4 ���޷��ж����� ��ʶ��������Ӧ<6 (�޷��ƶ�)����ʶ������<6 �޷��罻
     * �����ж���0���ɽӴ��ߣ�1-5 ����ޱȣ�5-10 ��ª��10-15 �Գ�15-20 Ѱ����20-25 ��ׯ��25-30�ɰ���30-35 ���� 35-39 �����ǣ�40 ��������
     * ��ֳ������11>�� ��ֳ����=0��11-13�� ��ֳ����=10��14<�� ��ֳ��=20��
     * �;�ֵ�ͷ������Լ�ֵ = ���Լ�ֵ*(�;�/�;�ֵ����)
     * �����;����޳ͷ���0-3�� ����0.5�� 3-13�� ����0.5+0.05*���䣬 70��-100�� ����1-0.02*����
     * �������Լ�ֵ�ͷ�����������ʶ�ͷ�ֳ������0-3�� ȫ����=4������=0�� 3-13�� ����0.5+0.05*���䣬 70��-100�� 1-0.02*����
     * �����������ƶ���Ǳ�У����ܣ����罻����ʳ, ���ƣ�����Я����װ��������������������������רҵ���ܣ��츳������
     * ����Node����ֵ��������ֵ�;����ޣ���ֵ������ڲ����ٶ�Ӧ�ⲿ����NodeId(�������-1�������ⲿ����),��ֵ���Լ�ֵ��
     * ���ٱ��ϣ��;�=0ʱ������ʧ,���ⲿ������ʧʱ��Ӧ�ڲ�����Ҳȫ����ʧ��
     * �����˺����ͣ����ۻ������̣�������
     * �ۻ�����ͷ��������װ�������ӳɣ������޷��������ڲ����٣��޷���Ѫ�����ι������˲�λ1��2
     * ���̣����·��̣������Ѫ+1,���ι������˲�λ1
     * ���������·����������Ѫ����+2�����˲�λ1��2
     * ���ж���������ʱ�������ⲿ���ٲ�λ���/ȫ�ⲿ����������ʼ�����ܻ���λ����������˺�>�������˺�����Ϊ���̻������������ж���Ӧ�ڲ��������/�ⲿ��������ж��ڲ������Ƿ����ˡ�
     * �ⲿ����id = -1����������Ϊ�ⲿ����
     * Node����ȫΪ��ֵ��ʵ�������ο���ֵ����׼��Ϊ1����������
     */
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Test");
        //// ����, ����,������ ��֪����Ӧ�����������ߣ���������ʶ����ֳ�����ָ�����
        //MobNode mobNode = new MobNode("����", 0, "", "����", new List<int>(){0,1,2,2,3,4,5,5,6,7,8,9,10,11,12,13,15,15,17,18,21,22,22,24,24,26}, new List<int>(){0,1,2,4}, 10,
        //    60, 70,new List<string>(){"Move"},new List<string>(){"eat"},new List<double>(){4,0.5,0.7});
        //MobNode mobNode2 = new MobNode("Ů��", 1, "", "Ů��", new List<int>() { 0, 1, 2, 2, 3, 4, 5, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15, 15,16, 17, 19, 20, 23, 23, 25, 25, 26 }, new List<int>() { 0, 1, 2, 4 }, 8,
        //    50, 75, new List<string>() { "Move" }, new List<string>() { "eat" }, new List<double>() { 4, 0.5, 0.7 });


        //MobPoolManager m = new MobPoolManager();
        //m.Add(mobNode);
        //m.Add(mobNode2);
        ////m.Add(r3);
        ////m.Add(r4);
        ////m.Add(r5);
        //Debug.Log("m " + m.Pool[0].NodeName);
        //m.SavePool();
        //MobPoolManager x = new MobPoolManager();
        //x.LoadPool();
        //Debug.Log("x" + x.Pool[1].NodeName);

    }

    // Update is called once per frame
    void Update()
    {
    }
}