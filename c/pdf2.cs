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
    }while(!StackEmpty(S));
    return FlASE;
}