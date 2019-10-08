//求线性表LA和LB的并集
void Union(List &La,List Lb) {
	La.len = ListLength(La);
	Lb.len - ListLength(Lb);
    for(i=1;i<Lb.len;i++) {
        GetElem(Lb,i,e); //取Lb中第i个数据元素赋给e
        if(!LocateElem(La,e,equal)){
            //La中不存在和e相同的数据元素，则插入之
            ListInsert(La,++La.len;e);
        }
    }
}

//归并La和Lb得到新的线性表Lc，Lc的数据元素也是按非递减排列
void MergeList(List La,List Lb,List &Lc) {
    //La和Lb中数据元素按值非递增排列
    InitList(Lc);
    i =j = 1;k=0;
    La.len = ListLength(La);
    Lb.len = ListLength(Lb);
    while((i<=La.len) && (j<=Lb.len)) {
        GetElem(La,i,ai);
        GetElem(Lb,i,bi);
        if(ai<=bi) {
            ListInsert(Lc,++k,ai);++i;
        } else {
            ListInsert(Lc,++k,bi);++j;
        }
    }
    while(i<=La.len) {
        GetElem(La,i,ai);
        ListInsert(Lc,++k,ai);
    }
    while(j<=Lb.len) {
        GetElem(Lb,i,bi);
        Listinsert(Lc,++k,bj);
    }
}

//线性表的存储结构
#define List_Init_Size 100 //线性表存储空间 初始化分配量
#define ListIncrement  10  //线性表存储空间 分配增量
