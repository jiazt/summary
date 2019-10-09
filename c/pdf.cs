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

//<------- 顺序表  -------->
//线性表的存储结构
#define List_Init_Size 100 //线性表存储空间 初始化分配量
#define ListIncrement  10  //线性表存储空间 分配增量
typedef struct {
    ElemType * elem;  //存储空间基址
    int length;   //当前长度
    int listsize; //当前分配的存储容量
}SqList;

//构造一个空的线性表L
Status InitList_Sq(SqList &L) {
    L.elem = (ElemType *)malloc(List_Init_Size * sizeof(ElemType));
    if(! L.elem) {
        exit(OVERFLOW);
    }
    L.length = 0;
    L.listsize = List_Init_Size;
    return OK;
}

//在顺序表L中第i个位置之前插入新的元素e
Status ListInsert_Sq(SqList &L,int i,ElemType e) {
    if(i<1||i>L.length+1) {
        return ERROR;
    }
    if(L.length >= L.listsize) {
        newbase = (ElemType *)realloc(L.elem,(L.listsize + ListIncrement)*sizeof(ElemType));
        if(!newbase) {
            exit(OVERFLOW);
        }
        L.elem = newbase;
        L.listsize += ListIncrement;
    }
    q = &(L.elem[i-1]);
    for(p = &(L.elem[L.length-1]);p>=q;--p) {
        *(p + 1) = *p;
    }
    *q = e;
    ++L.length;
    return OK;
}

//在顺序表L中删除第i个元素，并用e返回其值
Status ListDelete_Sq(SqList &L, int i, ElemType &e) {
    if((i<1) ||(i>L.length)) {
        return ERROR;
    }
    p = &(L.elem[i-1]); //p为被删除元素的位置
    e = *p;    //被删除元素的值赋给e
    q = L.elem + L.length - 1;  //表尾元素的位置
    for(;p<=q;++p) {
        *(p-1) = p;
    }
    --L.length;
    return OK;
}

//在顺序线性表L中查找第1个值与e满足compare()的元素的位序
int LocateElem_Sq(SqList L,ElemType e,Status(*compare)(ElemType,ElemType)) {
    i = 1; //i的初值为第1个元素的位序
    p = L.elem;  //p的初值为第1个元素存储位置
    while(i<=L.length && !(*compare(*p++ , e))) {
        ++i;
    }
    if(i <= L.length) {
        return i;
    } else {
        return 0;
    }
}

//归并La和Lb得到新的线性顺序表Lc，Lc元素也按值非递减排列
void MergeList_Sq(SqList La, SqList Lb, SqList &Lc) {
    pa = La.elem;
    pb = Lb.elem;
    Lc.listsize = Lc.length = La.length + Lb.length;
    pc = Lc.elem = (ElemType *)malloc(Lc.listsize*sizeof(ElemType));
    if(!Lc.elem) {
        exit(OVERFLOW);
    }
    pa_last = La.elem + La.length - 1;
    pb_last = Lb.elem + Lb.length - 1;
    while(pa < = pa_last && pb <= pb_last) {
        if(*pa <= *pb) {
            *pc++ = *pa++;
        } else {
            *pc++ = *pb++;
        }
    }
    while(pa <= pa_last) {
        *pc++ = *pa++;
    }
    while(pb <= pb_last) {
        *pc++ = *pb++;
    }
}

// <------ 链式表 -------->
//当第i个元素存在时，其值赋给e
Status GetElem_L(LinkList L, int i,ElemType &e) {
    p = L->next;
    j = 1;
    while(p && j < i) {
        p = p -> next;
        j++;
    }
    if(!p || j > i) {
        return ERROR;
    }
    e = p -> data;
    return OK;
}

//在带头借点的单链线性表L中第i个位置之前插入元素e
Status ListInsert_L(LinkList &L, int i, ElemType e) {
    p = L;
    j = 0;
    while(p && j < i-1) {
        p = p -> next;
        j++;
    }
    if(!p && j > i) {
        return ERROR;
    }
    s = (LinkList)malloc(sizeof(LNode));
    s -> data = e;
    s -> next = p -> next; //插入L
    p -> next = s;
    return OK;
}

//在带头结点的单链线性表L中，删除第i个元素，并由e返回其值
Status ListDelete_L(LinkList &L, int i, ElemType &e) {
    p = L;
    j = 0;
    while(p -> next && j < i-1) {
        p = p -> next;
        ++j;
    }
    if(!(p -> next) || j > i-1) {
        return ERROR;
    }
    q = p -> next;
    p -> next = q -> next;
    e = q -> data;
    free(q);
    return OK;
}

//逆位序输入n个元素的值，建立带投结点的单链线性表L
void CreateList L(LinkList &L,int n) {
    L = (LinkList)malloc(sizeof(LNode));
    L -> next = NULL; //先建立一个头结点的单链表
    for(i=n;i>0;--i) {
        p = (LinkList)malloc(sizeof(LNode));
        scanf(& p-> data);
        p -> next = L -> next;
        L -> next = p;
    }
}