
import java.util.*;

class StableMatching {
    public static int m; // số người đàn ông
    public static int w; // số người đàn bà

    // hàm này trả về true nếu người i được người phụ nữ thích hơn người j
    // f là vị trí của người phụ nữ trong bảng
    static boolean stableMatching(int i, int j, int f, int woman[][]) {
        // duyệt qua danh sách thứ tự người đàn ông sắp xếp theo độ yêu thích của người
        // phụ nữ.
        for (int k = 0; k < m; k++) {
            // nếu thích người i trước
            if (woman[f][k] == i) {
                return true;
            }

            // nếu thích người j trước
            if (woman[f][k] == j) {
                return false;
            }
        }
        return false;
    }

    public static void main(String[] args) {
        // danh sách thứ tự ưa thích của đàn ông
        int man[][] = new int[][] { { 2, 1, 3, 4 }, { 2, 4, 3, 1 }, { 3, 2, 1, 4 }, { 4, 3, 1, 2 }, };

        // danh sách thứ tự ưa thích của phụ nữ
        int woman[][] = new int[][] { { 3, 2, 4, 1 }, { 4, 1, 3, 2 }, { 2, 3, 4, 1 }, { 1, 2, 3, 4 } };

        // gán giá trị số người đàn ông và số người phụ nữ
        m = man.length;
        w = woman.length;

        // mảng đã ngỏ lời
        boolean seen[][] = new boolean[m][w];
        boolean mFree[] = new boolean[m];
        int wPartner[] = new int[w];

        // khởi tạo giá trị ghép đôi là chưa được ghép
        Arrays.fill(wPartner, -1);

        int freeMan = m;
        // trong khi có người đàn ông chưa được ghép
        while (freeMan > 0) {
            int i;
            for (i = 0; i < m; i++) {
                if (mFree[i] == false) {
                    break;
                }
            }

            // người con gái thứ j thích hơn mà chưa ngỏ lời
            int j=0;
            for (int k = 0; k < w; k++) {
                if (!seen[i][k]) {
                    seen[i][k] = true;
                    j = man[i][k];
                    break;
                }
            }

            // đi hỏi thăm lần lượt từng người con gái để ghép đôi
            // nếu cô gái còn chưa được ghép cặp
            if (wPartner[j-1] == -1 && !mFree[i]) {
                wPartner[j-1] = i + 1;
                mFree[i] = true;
                freeMan--;
            } else {
                // nếu cô đã được ghép cặp thì thực hiện so sánh người i và người cô đã ghép
                if (!mFree[i] && stableMatching(i + 1, wPartner[j-1], j-1, woman)) {
                    mFree[i] = true;
                    mFree[wPartner[j-1] - 1] = false;
                    wPartner[j-1] = i + 1;
                }
            }
        }

        for (int x = 0; x < w; x++) {
            System.out.println(wPartner[x]);
        }

    }
}
