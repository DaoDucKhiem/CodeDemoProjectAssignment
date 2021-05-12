import java.util.*;
import java.lang.*;
import java.io.*;

class GFG {
    // M là số người nộp đơn
    // N là số công việc
    static final int M = 4;
    static final int N = 4;

    // Hàm đệ quy dựa trên DFS trả về true nếu matching với đỉnh u
    boolean bpm(boolean bpGraph[][], int u, boolean seen[], int matchR[]) {
        // Thử công việc với từng người
        for (int v = 0; v < N; v++) {
            // Nếu người u quan tâm đến công việc v
            // và v chưa được thăm
            if (bpGraph[u][v] && !seen[v]) {

                // Đánh dấu v là đã thăm
                seen[v] = true;

                // Nếu công việc v chưa được giao cho ứng viên
                // hoặc ứng viên đã được giao cho công việc v trước đó
                // (tức là matchR[v] có sẵn công việc khác thay thế.
                // Vì v được đánh dấu là đã thăm ở trên nên matchR[v]
                // trong lệnh gọi đệ quy sẽ không nhận được lệnh v nữa)
                if (matchR[v] < 0 || bpm(bpGraph, matchR[v], seen, matchR)) {
                    matchR[v] = u;
                    return true;
                }
            }
        }
        return false;
    }

    // Trả về số lượng matching tối đa từ M đến N
    int maxBPM(boolean bpGraph[][]) {
        // Một mảng để theo dõi các ứng viên được các công việc.
        // Giá trị của matchR[i] là số ứng viên được chỉ định cho công việc i,
        // Nếu không ai được chỉ định thì giá trị là -1.
        int matchR[] = new int[N];

        // Ban đầu tất cả các công việc đều chưa được giao
        for (int i = 0; i < N; ++i)
            matchR[i] = -1;

        // Số lượng công việc được giao cho ứng viên
        int result = 0;
        for (int u = 0; u < M; u++) {
            // Đánh dấu tất cả các công việc chưa 
            // được thăm bởi ứng viên tiếp theo
            boolean seen[] = new boolean[N];
            for (int i = 0; i < N; ++i)
                seen[i] = false;

            // Tìm xem ứng viên u có thể có được công việc không
            if (bpm(bpGraph, u, seen, matchR))
                result++;
        }

        // in ra kết quả matching
        for (int i = 0; i < M; i++) {
            System.out.print((matchR[i] + 1) + " ");
        }
        System.out.println();
        return result;
    }

    // Khởi chạy
    public static void main(String[] args) throws java.lang.Exception {
        // Chúng ta tạo một bpGraph cho ví dụ ở trên.

        boolean bpGraph[][] = new boolean[][] {
            { false, true, false, true },
            { true, false, false, false },
            { false, true, true, false },
            { false, false, true, false } 
        };
        GFG m = new GFG();
        System.out.println("Số lượng tối đa ứng viên có thể có được công việc là " + m.maxBPM(bpGraph));
    }
}