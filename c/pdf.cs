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

//归并La和Lb得到新的单链表Lc
void MergeList_L(LinkList &La, LinkList &Lb, LinkList &Lc) {
    pa = La -> next;
    pb = Lb -> next;
    Lc = pc = La;
    while(pa && pb) {
        if(pa -> data <= pb -> data) {
            pc -> next = pa;
            pc = pa;
            pa = pa -> next;
        } else {
            pc -> next =pb;
            pc = pb;
            pb = pb -> next;
        }
    }
    pc -> next = pa ? pa : pb;
    free(Lb);
}

// <----- 线性表的静态单链表 ------>
//用游标（指示器cur）代替指针指示结点在数组中的相对位置
#define MaxSize 1000
typedef struct {
    ElemType data;
    int cur;
}component,SLinkList[MaxSize];

//在静态单链线性表L中查找第1个值为e的元素
int LocateElem_SL(SLinkList S,ElemType e) {
    i = S[0].cur;
    while(i && S[i].data != e) {
        i = S[i].cur;
    }
    return i;
}

//将一维数组space中各分量链成一个备用链表，space[0].cur为头指针。
void InitSpace_SL(SLinkList &space) {
    for(i = 0;i < MaxSize;i++) {
        space[i].cur = i+1;
    }
    space[MaxSize-1].cur = 0;
}

//若备用空间链表非空，则返回分配的结点下标，否则返回0
int Malloc_SL(SLinkList &space) {
    i = space[0].cur;
    if(space[0].cur){
        space[0].cur = space[i].cur;
    }
    return i;
}

//将下标为k的空闲结点回收到备用链表
void Free_SL(SLinkList &space, int k) {
    space[k].cur = space[0].cur;
    space[0].cur = k;
}

//（A-B）∪ (B-A) ***
void Difference(SLinkList &space, int &s) {
    InitSpace_SL(space);
    S = Malloc_SL(space);
    r = S;
    scanf(m, n);
    for(j = 1;j <= m;++j) {
        i = Malloc_SL.SL(space);
        scanf(space[i].data);
        space[r].cur = i;
        r = i;
    }
    space[r].cur = 0;
    for(j = 1;j <= n;++j) {
        scanf(b);
        p = S;
        k = space[S].cur;
        while(k != space[r].cur && space[k].data != b) {
            p = k;
            k = space[k].cur;
        }
        if(k == space[r].cur) {
            i = Malloc_SL(space);
            space[i].data = b;
            space[i].cur = space[r].cur;
            space[r].cur = i;
        } else {
            space[p].cur = space[k].cur;
            Free_SL(space,k);
            if(r == k) {
                r = p;
            }
        }
    }
}

//<---- 双向链表 ------>

// typedef struct DuLNode {
//     ElemType data;
//     struct DuLNode *prior;
//     struct DuLNode *next;
// }DuLNode,*DuLinkList;

//在带头结点的双链循环线性表L中第i个位置之前插入元素e
Status ListInsert_Dul(DuLinkList &L, int i, ElemType e) {
    if(!(p = GetElemP_DuL(L, i))) {
        return ERROR;
    }
    if(!(s = (DuLinkList)malloc(sizeof(DuLNode)))) {
        return ERROR;
    }
    s -> data = e;
    s -> prior = p -> prior; //先接前，再接后
    p -> prior -> next = s;
    s -> next = p;
    p -> prior = s;
    return OK;
}

//删除带头结点的双链循环线性表L的第i个元素，i的合法值为1<=i<=表长
Status ListDelete_DuL() {
    if(!(p = GetElemP_DuL(L, i))) {
        return ERROR;
    }
    e = p -> data;
    p -> prior -> next = p -> next;
    p -> next -> prior = p -> prior;
    free(p);
    return OK;
}

//在带头结点的单链线性表L的第i个元素之前插入元素e
Status ListInsert_L(LinkList &L, int i, ElemType e) {
    if(!LocatePos(L, i - 1, h)) { //i值不合法
        return ERROR;
    }
    if(!MakeNode(s, e)) {
        return ERROR;
    }
    InsFirst(h, s);//对于从第i个结点开始的链表，第i-1个
    return OK;
}

//归并La和Lb得到新的线性链表Lc
Status MergeList_L(LinkList &La,LinkList &Lb, LinkList &Lc) {
    if(!InitList(Lc)) {//存储空间分配失败
        return ERROR;
    }
    ha = GetHead(La);
    hb = GetHead(Lb);
    pa = NextPos(La,ha);
    pb = NextPos(Lb,hb);
    while(pa && pb) {
        a = GetCurElem(pa);
        b = GetCurElem(pb);
        if((*compare)(a, b) <= 0) {
            DelFirst(ha, q);
            Append(Lc, q);
            pa = NextPos(La, ha);
        } else {
            DelFirst(hb, q);
            Append(Lc, q);
            pb = NextPos(Lb, hb);
        }
    }
    if(pa) {
        Append(Lc, pa);
    } else {
        Append(Lc, pb)
    }
    FreeNode(ha);
    FreeNode(hb);
    return OK;
}

//抽象数据类型polynomial的实现
typedef struct {
    float coef;  //系数
    int expn;    //指数
}term, ElemType;// term用于本ADT，Elemtype为LinkList的数据对象名

//输入m项的系数和指数，建立表示一元多项式的有序链表P
void CreatePolyn(polynomail &P, int m) {
    InitList(P);
    h = GetHead(P);
    e.coef = 0.0;
    e.expn = -1;
    SetCurElem(h,e);
    for(i = 1 ; i <= m ; i++) {
        scanf(e.coef,e.expn);
        if(!LocateElem(P,e,q,(*cmp))) { //当前链表中不存在该指数项
            if(MakeNode(s, e)) {
                InsFirst(q, s); //生成结点并插入链表
            }
        }
    }
}

// 多项式加法；Pa = Pa + Pb利用两个多项式结点构成“和多项式”
void AddPolyn(polynomail &Pa, polynomail &Pb) {
    ha = GetHead(Pa);
    hb = GetHead(Pb);
    qa = NextPos(Pa,ha);
    qb = NextPos(Pb,hb);
    while(qa && qb) {
        a = GetCurElem(qa);
        b = GetCurElem(qb);
        switch(*cmp(a, b)) {
            case -1: //多项式
                ha = qa;
                qa = NextPos(Pa,qa);
                break;
            case 0:
                sum = a.coef + b.coef;
                if(sum != 0.0) {
                    SetCurElem(ha, qa);
                    ha = qa;
                } else {
                    DelFirst(ha, qa);
                    FreeNode(qa);
                }
                DelFirst(hb,qb);
                FreeNode(qb);
                qb = NextPos(Pb,hb);
                qa = NextPos(Pa,ha);
                break;
            case 1:
                DelFirst(hb, qb);
                InsFirst(ha, qb);
                qb = NextPos(Pb, hb);
                ha = NextPos(Pa, ha);
                break;
        }
    }
    if(!ListEmpty(Pb)) {
        Append(Pa,qb);
    }
    FreeNode(hb);
}

//顺序栈的定义
#define Stack_Int_Size 100; //存储空间初始化分配
#define StackIncrement 10;  //存储空间分配增量
typedef struct {
    SElemType *base; //存储空间初始分配量
    SElemType *top;
    int stacksize;
}SqStack;

//构造一个空栈S
Status InitStack(SqStack &S) {
    S.base = (SElemType *)malloc(Stack_Int_Size*sizeof(SElemType));
    if(!S.base) {
        exit(OVERFLOW);
    }
    S.top = S.base;
    S.stacksize = Stack_Int_Size;
    return OK;
}

//若栈不空，则用e返回S的栈顶元素，并返回OK；否则返回ERROR
Status GetTop(SqStack S,SElemType &e) {
    if(S.top == S.base) {
        return ERROR;
    }
    e = *(S.top - 1);
    return OK;
}

//插入元素e为新的栈顶元素
Status Push(SqStack &S, SElemType e) {
    if(S.top - S.base >= S.stacksize) {//栈满，追加存储空间
        S.base = (SElemType*)realloc(S.base,(S.stacksize +　StackIncrement)*sizeof(SElemType));
        if(!S.base) {
            exit(OVERFLOW);
        }
        S.top = S.base + S.stacksize;
        S.stacksize += StackIncrement;
    }
    *S.top++ =e;
    return OK;
}

//若栈不空，则删除S的栈顶元素，用e返回其值，并返回
Status Pop(SqStack &S, SElemType &e) {
    if(S.top == S.base) {
        return ERROR;
    }
    e = *--S.top;
    return OK;
}

//栈的应用
//对于输入的任意一个非十进制整数，打印输出与其等值的八进制数
void conversion() {
    InitStack(S);
    scanf("%d",N);
    while(N) {
        Push(S , N%8);
        N = N/8;
    }
    while(!StackEmpty(s)) {
        Pop(S,e);
        printf("%d",e);
    }
}

//利用字符栈S，从中端接受一行并传送至调用过程的数据区
void LineEdit() {
    InitStack(S);
    ch = getchar();
    while(ch != EOF) {
        while(ch! = EOF && ch != '\n') {
            switch(ch) {
                case '#': //仅当栈非空时退栈
                    Pop(S,c);
                    break;
                case '@':
                    ClearStack(S);
                default: 
                    Push(S,ch);
            }
            ch = getchar();
        }
        ClearStack(S);
    }
    DestroyStack(S);
}

//若迷宫maze中存在从入口start到出口end的通道，则求得一条存放在栈中（从栈底到栈顶），并返回true；否则false
Status MazePath(MakeType maze, PosType start, PosType end) {
    InitStack(S);
    curpos = start;
    curstep = 1;
    do {
        if(Pass(curpos)) {
            FootPrint(curpos);
            e = (curstep, curpos, 1);
            Push(S,e);
            if(curpos == end) {
                return TRUE;
            }
            curpos = NextPos(curpos, 1);
            curstep++;
        } else {
            if(!StackEmpty(S)) {
                Pop(S,e);
                while(e.di === 4 && !StackEmpty(S)) {
                    MarkPrint(e.seat);
                    Pop(S,e);
                }
                if(e,di < 4) {
                    e.di ++;
                    Push(S, e);
                }
            }
        }
    } while(!StackEmpty(S));
    return FlASE;
}

//算术表达式求值的算符优先算法，设OPTR和OPND分别为运算符栈和运算数栈
OperandType EvaluateExpression() {
    InitStack(OPTR);
    Push(OPTR,'#');
    InitStack(OPND);
    c = getchar();
    while(c != '#' || GetTop(OPTN, c) != '#') {
        if(!In(c, OP)) { //不是运算符则进栈
            Push(OPND , c);
            c = getchar();
        } else {
            switch(Precede(GetTop(OPTR),c)) {
                case '<': //栈顶元素优先级低
                    Push(OPTR, c);
                    c = getchar();
                    break;
                case '=': //脱括号并接收下一字符
                    Pop(OPTR, x);
                    c = getchar();
                    break;
                case '>': //退栈并将运算结果入栈
                    Pop(OPTR, theta);
                    Pop(OPND, b);
                    Pop(OPND, a);
                    Push(OPND, Operate(a, theta, b));
                    break;
            } 
        }
    }
    return GetTop(OPND);
}

//汉诺塔，将塔座x上按直径由小到大且自上而下编号1至n个原盘规则搬到
//塔座z上，y可作辅助塔座。
//搬动操作move(x, n, z)可定义为(c是初值为0的全局变量，对搬动计数)
void hanoi(int n, char x, char y, char z) {
    if(n === 1) {
        move(x, 1, z); //将编号为1的圆盘从x移动到z
    } else {
        hanoi(n-1, x, z, y);//将x上编号为1至n-1的圆盘移到y，z作铺助塔
        move(x, n ,z);      //将编号为n的圆盘从x移到z
        hanoi(n-1, y, x, z);//将y上编号为1至n-1的圆盘移到z
    }
}

// <----- 单链队列  队列的链式存储结构 ------>
// typedef struct QNode {
//     QElemType data;
//     struct QNode *next;
// }QNode, *QueuePtr;
typedef struct {
    QueuePtr front;  //队头指针
    QueuePtr rear;
}LinkQueue;

//构造一个空队列Q
Status InitQueue(LinkQueue &Q) {
    Q.front = Q.rear = (QueuePtr)malloc(sizeof(QNode));
    if(!Q.front) {
        exit(OVERFLOW);//存储分配失败
    }
    Q.front -> next = NULL;
    return OK;
}

//销毁队列Q
Status DestroyQueue(LinkQueue &Q) {
    while(Q.front) {
        Q.rear = Q.front -> next;
        free(Q.front);
        Q.front = Q.rear;
    }
    return OK;
}

//插入元素e为Q的新的队列元素
Status EnQueue(LinkQueue &Q, QElemType e) {
    p = (QueuePtr)malloc(sizeof(QNode));
    if(!p) {
        exit(OVERFLOW);   //存储分配失败
    }
    p -> data = e;
    p -> next = NULL;
    Q.rear -> next = p;
    Q.rear = p;
    return OK;
}

//若队列不空，则删除Q的队头元素，用e返回其值，并返回OK
Status DeQueue(LinkQueue &Q, QElemType &e) {
    if(Q.front == Q.rear) {
        return ERROR;
    }
    p = Q.front -> next;
    e = p -> data;
    Q.front -> next = p -> next;
    if(Q.rear == p) {
        Q.rear = Q.front;
    }
    free(p);
    return OK;
}

//<------ 循环队列 ------>
#define MaxQSize 100
typedef struct {
    QElemType *base; //初始化的动态分配储存空间
    int front;       //头指针，若队列不空，指向队列头元素
    int rear;        //尾指针，若队列不空，指向队列尾元素的下一个位置
}SqQueue;

//构造一个空队列Q
Status InitQueue(SqQueue &Q) {
    Q.base = (QElemType*)malloc(MaxQSize*sizeof(QElemType));
    if(!Q.base) {
        exit(OVERFLOW);
    } 
    Q.front = Q.rear = 0;
    return OK;
}

//返回Q的元素个数，即队列的长度
int QuereLength(SqQueue Q) {
    return(Q.rear - Q.front + MaxQSize) % MaxQSize;
}

//插入元素e为Q的新队尾元素
Status EnQueue(SqQueue &Q, QElemType e) {
    if((Q.rear + 1) % MaxQSize == Q.front) {
        return ERROR;
    }
    Q.base[Q.rear] = e;
    Q.rear = (Q.rear + 1) % MaxQSize;
    return OK;
}

//若队列不空，则删除Q的队头元素，用e返回其值，并返回OK
Status DeQueue(SqQueue & Q, QElemType &E) {
    if(Q.front == Q.rear) {
        return ERROR;
    }
    e = Q.base[Q.front];
    Q.front = (Q.front + 1) % MaxQSize;
    return OK;
}

//银行业务模拟，统计一天内客户在银行逗留的平均时间
void Bank_Simulation(int CloseTime) {
    OpenForDay();
    while(MoreEvent) {
        EventDrived(OccurTime, EventType); //事件驱动
        switch(EventType) {
            case 'A': 
                CustomerArrived();  //处理客户到达事件
                break;
            case 'D':
                CustomerDeparture(); //处理客户离开事件
                break;
            default: 
                Invalid();
        }
    }
    CloseForDay()  //计算平均逗留时间
}

//二叉树的存储结构
#define Max_Tree_Size 100;
typedef TElemType SqBiTree[Max_Tree_Size];
SqBiTree bt;

//先序遍历二叉树T的递归算法，对每个数据元素调用方式Visit
Status PreOrderTraverse(BiTree T.Status(* Visit)(TElemType e)) {
    // Status PrintElement(TElemType e) {
    //     printf(e);
    //     return OK;
    // }
    if(T) {
        if(Visit(T -> data)) {
            if(PreOrderTraverse(T -> lchild.Visit)) {
                if(PreOrderTraverse(T -> rchild.Visit)) {
                    return OK;
                }
            }
        }
        return ERROR;
    } else {
        return OK;
    }
}

//采用二叉链表存储结构，Visit是对数据元素操作的应用函数
Status InOrderTraverse(BiTree T.Status(*Visit)(TElemType e)) {
    InitStack(S);
    Push(S,T);
    while(!StackEmpty(S)) {
        while(GetTop(S,p) && p) {
            Push(S, p -> lchild); //向左走到尽头
        }
        Pop(S, p);                //空指针退栈
        if(!StackEmpty(S)) {      //访问结点，向右一步
            Pop(S, p);
            if(!Visit(p -> data)) {
                return ERROR;
            }
            Push(S, p -> rchild);
        }
    }
    return OK;
}

//采用二叉链表存储结构，visit是对数据元素操作的应用函数
//中序遍历二叉树T的非递归算法，对每个元素调用函数Visit
Status InOrderTraverse(BiTree T.Status(* Visit)(TElemType e)) {
    IninStack(S);
    p = T;
    while(p || !StackEmpty(S)) {
        if(p) {
            Push(S, p);
            p = p -> lchild;   //根指针进栈，遍历左子树
        } else {               //根指针退栈，访问根结点，遍历右子树
            Pop(S, p);
            if(!Visit(p -> data)) {
                return ERROR;
            }
            p = p -> rchild;
        }
    }
    return OK;
}

//按先序次序输入二叉树中结点的值，空格字符表示空树
Status CreateBiTree(BiTree &T) {
    scanf(&ch);
    if(ch == '') {
        T = null;
    } else {
        if(!(T = (BiTNode * )malloc(sizeof(BiTNode)))) {
            exit(OVERFLOW);
            T -> data = ch;
            CreateBiTree(T -> lchild);
            CreateBiTree(T -> rchild);
        }
    }
    return OK;
}

//<-----二叉树的二叉线索存储表示------>
typedef enum PointerTag { Link, Thread };
typedef struct BiTrNode {
    TElemType data,
    struct BiTreNode *lchild, *rchild;
    PointerTag LTag, Rtag;
}BiThrNode, *BiThrTree;

//中序遍历二叉线索树T的非递归算法，对每个数据元素调用函数Visit
Status InOrderTraverse_Thr(BiThrTree T.Status(*Visit)(TElemType e)) {
    p = T -> lchild;   //p指向根结点
    while(p != T) {    //空树或遍历结束时，p == T
        while(p -> LTag == Link) {
            p = p -> lchild;
        }
        if(!Visit(p -> data)) {
            return ERROR;
        }
        while(p -> RTag == Thread && p -> rchild != T) {
            p = p -> rchild;
            Visit(p -> data);
        }
        p = p -> rchild;
    }
    return OK;
}

//算法6.5 中序遍历二叉树T，并将其中序线索化，Thrt指向头结点
Status InOrderThreading(BiThrTree &Thrt, BiThrTree T) {
    if(!(Thrt = (BiThrTree)malloc(sizeof(BiThrTree)))) {
        exit(OVERFLOW);
    }
    Thrt -> LTag = Link;   //建头结点
    Thrt -> RTag = Thread;
    Thrt -> rchild = Thrt;  //右指针回指
    if(!T) {
        Thrt -> lchild = Thrt; //若二叉树空，则左指针回指向
    } else {
        Thrt -> lchild = T;
        pre = Thrt;
        InThreading(T);  //中序遍历进行中序线索化
        pre -> rchild = Thrt; //最后一个结点线索化
        pre -> RTag = Thread;
        Thrt -> rchild = pre;
    }
    return OK;
}

//算法6.6
void InThreading(BiThrTree p) {
    if(p) {
        InThreading(p -> lchild); //左子树线索化
        if(!p -> lchild) { //前驱线索
            p -> LTag = Thread;
            p -> lchild = pre;
        } 
        if(!pre -> rchild) { //后继线索
            pre -> RTag = Thread;
            pre -> rchild = p;
        }
        pre = p;
        InThreading(p -> rchild);
    }
}

//<------- 树和森林  ---------》
#define Max_Tree_Size 100
typedef struct PTNode { //结点机构
    TElemType data;
    int parent;   //双亲位置域
}PTNode;
typedef struct { //树结构
    PTNode nodes[Max_Tree_Size];
    int r,n;  //根的位置和结点树
}PTree;

//----树的孩子链表存储表示-------
// typedef struct CTNode {
//     int child;
//     struct CTNode *next;
// }*ChildPtr;
typedef struct {
    TElemType datal
    ChildPtr firstchild;  //孩子链表头指针
}CTBox;
typedef struct {
    CTBox node[Max_Tree_Size];
    int n,r;   //结点数和根的位置
}CTree;

// -----树的二叉链表（孩子-兄弟）存储表示------
// typedef struct CSNode {
//     ElemType data;
//     struct CSNode *firstchild, *nextsibling;
// }CSNode, *CSTree;

//----ADT MFSet 的树的双亲表存储表示------
typedef PTree MFSet;
int find_mfset(MFSet S, int i) {
    //找集合S中i所在子集的根
    if(i < 1 || i > S.n) {
        return -1;
    }
    for(j = i ; S.node[j].parent > 0 ; j = S.node[j].parent);
    return j;
}

//算法6.8 求并集Si U Sj
Status merge_mfset(MFSet &S, int i, int j) {
    //S.nodes[i]和S.nodes[j]分别为S互不相交的两个子集Si和Sj的根结点
    if(i < 1 || i > S.n || j < 1 || j > S.n) {
        return ERROR;
    }
    S.nodes[i].parent = j;
    return OK;
}

//6.9求并集
void mix_mfset(MFSet &S, int i, int j) {
     if(i < 1 || i > S.n || j < 1 || j > S.n) {
        return ERROR;
    }
    if(S.nodes[j].parent > S.nodes[j].parent) {
        S.nodes[j].parent += S.nodes[i].parent;
        S.nodes[i].parent = j;
    } else {
        S.nodes[i].parent += S.nodes[j].parent;
        S.nodes[j].parent = i;
    }
}

//6.10 确定i所在子集，
// 并将从i至根路径上所有结点变成根的孩子结点。
int fix_mfset(MFSet &S,int i) {
    if(i < 1 || i > S.n) {
        return -1;
    }
    for(j = i;S.nodes[j].parent > 0; j = S.nodes[j].parent);
    for(k = i;k != j;k = t) {
        t = S.nodes[k].parent;
        S.nodes[k].parent = j;
    }
    return j;
}

//求含n个元素的集合A的幂集p(A)。进入函数时已对A中前i-1个元素作了取舍处理
//现从第i个元素起进行取舍处理。若i>n,则求得幂集的一个元素，并输出之
//初始调用：PowerSet(1 , n)
void PowerSet(int i, int n) {
    if(i > n) // 输出幂集的一个元素
    else {
        PowerSet(i + 1, n); //取第一个元素
        PowerSet(i + 1, n); //舍第一个元素
    }
}

//线性表A表示集合A，线性表B表示幂集P(A)的一个元素
//局部量k为进入函数时表B的当前长度。第一次调用函数时，B为空表，i = 1
void GetPowerSet(int i, List A, List &B) {
    if(i > ListLength(A)) {
        Output(B);
    } else {
        GetElem(A, i, x);
        k = ListLength(B);
        ListInsert(B, k+1 , x);
        GetPowerSet(i+1, A, B);
        ListDelete(B, k+1 ,x);
        GetPowerSet(i+1, A, B)
    }
}

//进入本函数时，在n X n棋盘前i-1行已放置了互不攻击的i-1个棋子
//现从第i行起继续为后续棋子选择适合位置
//当i>n时，求得一个合法布局，输出之
void Trial(int i, int n) {
    if(i >　n) //输出棋盘当前布局 n为4即为4皇后问题
    else {
        for(j = 1; j <= n ; ++j) {
            if(当前布局合法) {
                Trial(i+1 ,n);
            }
        }
    }
}

// ---图---



// ---查询---
//静态查找的顺序存储结构
typedef struct {
    ElemType *elem;
    int length;
}SSTable;

//在顺序表ST中顺序查找其关键字等于key的数据元素。若找到，则函数值为
//该元素在表中的位置，否则为0
//顺序查询
int Search_Seq(SSTable ST, KeyType Key) {
    ST.elem[0].key = key; //"哨兵"
    for(i = ST.length; !EQ(ST.elem[i].key, key) ; --i);
    return i;
}

//在有序表ST中折半查找其关键字等于key的数据元素。
//该元素在表中的位置，否则为0
//折半查找
int Search_Bin(SSTable ST, KeyType key) {
    low = 1;
    high = ST.length;
    while(low <= high) {
        mid = (low + high) / 2;
        if(EQ(key, ST.elem[mid].key)) {
            return mid;
        } else if(LT(key, ST.elem[mid].key)) {
            high = mid - 1;
        } else {
            low = mid + 1;
        }
    }
    return 0;
}

//---哈希表存储结构---
int hashsize[] = {998,...};
typedef struct {
    ElemType *elem;
    int count;
    int sizeindex;
}HashTable;

//在开放定址哈希表H中查找关键码为K的元素，若查找成功，以p指示
//元素在表中位置返回SUCCESS；否则，以p指示插入位置，并返回UNSUCCESS
//c用以计冲突次数，其初值置0,拱建表插入时参考
Status SearchHash(HashTable H, KeyType K, int &p, int &c) {
    p = Hash(K);   //求得哈希地址
    while(H.elem[p].key != NULLKEY &&  //该位置中填有记录
    !EQ(K,H.elem[p].key)) {   //并且关键字不想等
        collision(p, ++c)  //求得下一探查地址p
    }
    if(EQ(K, H.elem[p].key)) {
        return SUCCESS;
    } else {
        return UNSUCCESS;
    }
}

//查找不成功时插入数据元素e到开放定址哈希表H中，并返回OK
//若冲突次数过大，则重建哈希表
Status InsertHash(HashTable &H, ElemType e) {
    c = 0;
    if(SearchHash(H, e.key, p, c)) {
        return DUPLICATE;
    } else if(c <　hashsize[H.sizeindex]/2) {
        H.elem[p] = e;
        ++H.count;
        return OK;
    } else {
        RecreateHashTable(H);
        return UNSUCCESS;
    }
}

// ---排序---
#define MaxSize 20;
typedef int KeyType;
typedef struct {
    KeyType key;
    InfoType otherinfo;
}RedType;
typedef struct {
    RedType r[MaxSize + 1]; //r[0]闲置或哨兵单元
    int length;
}SqList;

//对顺序表L作直接插入排序
void InsertSort(SqList &L) {
    for(i = 2; i<=L.length; ++i) {
        if(LT(L.r[i].key, L.r[i-1].key)) { //‘<’
            L.r[0] = L.r[i];
            L.r[i] = L.r[i - 1];
            for(j = i-2 ; LT(L.r[0].key, L.r[i].key) ; --j) {
                L.r[j+1] = L.r[j];
            }
            L.r[j + 1] = L.r[0];
        }
    }
}

//插入排序 网上算法
void insertion_sort(int arr[], int len){
    int i,j,key;
    for (i=1;i<len;i++){
        key = arr[i];
        j=i-1;
        while((j>=0) && (arr[j]>key)) {
                arr[j+1] = arr[j];
                j--;
        }
        arr[j+1] = key;
    }
}

//对顺序表L作折半插入排序
void BInsertSort(SqList &L) {
    for(i = 2; i <= L.length; ++i) {
        L.r[0] = L.r[i];
        low = 1;
        high = i - 1;
        while(low <= high) {
            m = (low + high) / 2; //折半
            if(LT(L.r[0].key,L.r[m].key)) { //'<' 插入点在低半区
                high = m - 1；
            } else {    //插入点在高半区
                low = m + 1; 
            }
        }
        for(j = i -1 ; j >= high + 1; --j) {
            L.r[j+1] = L.r[j];
        }
        L.r[high + 1] = L.r[0];
    }
}

//对顺序表L作一趟希尔插入排序
//1.前后记录位置的增量是dk，而不是1；
//2.r[0]只是暂存单元，不是哨兵。当j<=0时，插入位置已找到
void ShellInsert(SqList &L, int dk) {
    for(i = dk + 1; i<= L.length ; ++i) {
        if(LT(L.r[i].key, L.r[i - dk].key)) { //需将L.r[i]插入有序增量子表
            L.r[0] = L.r[i]; //暂存在L.r[0]
            for(j = i - dk; j>0 && LT(L.r[0].key, L.r[j].key); j-=dk) {
                L.r[j + dk] = L.r[j];
            }
            L.r[j + dk] = L.r[0];
        }
    }
}

//按增量序列dlta[0..t-1]对顺序表L作希尔排序
void ShellSort(SqList &L, int dlta[] , int t) {
    for(k = 0;k < t; ++k) {
        ShellInsert(L, dlta[k]);
    }
}


//快速排序
//交换顺序表L中子表r[low..high]的记录
//在它之前（后）的记录均不大（小）于它
int Partition(SqList &L, int low, int high) {
    L.r[0] = L.r[low];
    pivotkey = L.r[low].key; //记录关键字
    while(low < high) {
        while(low < high && L.r[high].key >= pivotkey) {
            --high
        }
        L.r[low] = L.r[high];
        while(low < high && L.r[low].key <= pivotkey) {
            ++low;
        }
        L.r[high] = L.r[low];
    }
    L.r[low] = L.r[0];
    return low;
}

//对顺序表L作快速排序
void QSort(SqList &L, int low, int high) {
    if(low < high) {
        pivotkey = Partition(L, low, high);
        Qsort(L, low, pivotkey - 1);
        Qsort(L, pivotkey + 1, high);
    }
}

void QuickSort(SqList &L) {
    Qsort(L, 1, L.length);
}

//对顺序表L作简单选择排序
void SelectSort(SqList &L) {
    for(i = 1 ; i < L.length ; ++i) {
        j = SelectMinKey(L, i); //在L.r[i]中选择key最小的记录
        if(i != j) {
            k = L.r[i];
            L.r[i] = L.r[j];
            L.r[j] = k; 
        } 
    }
}

//选择排序 网上算法
void selection_sort(int arr[], int len) 
{
    int i,j;
    for (i = 0 ; i < len - 1 ; i++) 
    {
        int min = i;
        for (j = i + 1; j < len; j++)     //走訪未排序的元素
                if (arr[j] < arr[min])    //找到目前最小值
                        min = j;    //紀錄最小值
        swap(&arr[min], &arr[i]);    //做交換
    }
}

//堆排序
//已知H.r[s..m]中记录的关键字除H.r[s].key之外均满足堆的定义
//使H.r[s..m]成为一个大顶堆
void HeapAdjust(HeapType &H, int s, int m) {
    rc = H.r[s];
    for(j = 2*s ; j <= m ; j *= 2) {
        if(j < m && LT(H.r[j].key, H.r[j+1].key)) {
            ++j;
        }
        if(!LT(rc.key, H.r[j].key)) {
            break;
        }
        H.r[s] = H.r[j];
        s = j;
    }
    H.r[s] = rc;
}

//对顺序表H进行堆排序
void HeapSort(HeapType &H) {
    for(i = H.length/2 ; i > 0 ; --i) {
        HeapAdjust(H, i, H.length);
    }
    for(i = H.length; i>1; --i) {
        swap(H.r[1], H.r[i]);
        HeapAdjust(H, 1, i-1);
    }
}

//归并排序
//将有序的SR[i..M]
void Merge(RcdType SR[], RcdType &TR[], int i, int m, int n) {
    for(j = m + 1,k = i ; i <= m && j <= n ; ++k) {
        if(LQ(SR[i].key, SR[j].key)) {
            TR[k] = SR[i++];
        } else {
            TR[k] = SR[j++]
        }
    }
    if(i <= m) {
        TR[k..n] = SR[i..m]; //将剩余SR[i..m]复制到TR
    }
    if(j <= n) {
        TR[k..n] = SR[j..n]; //将剩余SR[j..n]复制到TR
    }
}

void MSort(RcdType SR[], RcdType &TR1[], int s, int t) {
    if(s == t) {
        TR1[s] = SR[s];
    } else {
        m = (s + t)/2; //将SR[s..t]平分为SR[s..m]和SR[m+1..t]
        MSort(SR, TR2, s, m); //递归将SR[s..m]归并为有序的TR2[s..m]
        MSort(SR, TR2, m + 1 ,t); //递归将SR[m+1..t]归并为有序的TR2[m+1..t]
        Merge(TR2)
    }
}