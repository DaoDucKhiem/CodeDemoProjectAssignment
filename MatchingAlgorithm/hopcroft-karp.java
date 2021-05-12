import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedList;
import java.util.Queue;

class GFG {

    static final int NIL = 0;
    static final int INF = Integer.MAX_VALUE;

    static class BipGraph {

        // m và n là lần lượt là số đỉnh ở bên trái
        // và bên phải của đồ thị hai phía
        int m, n;

        // adj[u] là danh sách kề. Giá trị của u
        // trong khoảng từ 1 đến m. 0 dành cho đỉnh giả
        ArrayList<ArrayList<Integer>> adj;

        // Những con trỏ cần thiết cho phương thức hopcroftKarp()
        int[] pairU, pairV, dist;

        // Returns size of maximum matching
        int hopcroftKarp() {

            // pairU lưu trữ ghép cặp của u trong cặp ghép khi
            // u là một đỉnh ở phía bên trái của đồ thị hai phía.
            // nếu u không match với đỉnh nào thì pairU là Nil (null)
            pairU = new int[m + 1];

            // pairV lưu trữ ghép cặp của v trong cặp ghép. Nếu V không
            // match thì pairV là Nil
            pairV = new int[n + 1];

            // dist[u] lưu trữ khoảng cách của các đỉnh bên trái. dist[u]
            // lớn hơn dist[u'] nếu u ở bên cạnh trong đường tăng.
            dist = new int[m + 1];

            // Khởi tạo Nil cho tất cả giá trị ghép cặp của các đỉnh
            Arrays.fill(pairU, NIL);
            Arrays.fill(pairV, NIL);

            // khởi tạo kết quả trả về
            int result = 0;

            // cập nhật kết quả khi có đường tăng
            while (bfs()) {

                // Tìm một đỉnh tự do
                for (int u = 1; u <= m; u++)

                    // Nếu đỉnh hiện tại là đỉnh tự do và có một đường tăng từ đỉnh hiện tại
                    if (pairU[u] == NIL && dfs(u))
                        result++;
            }
            for (int i = 0; i <= m; i++) {
                System.out.println(pairU[i]);
            }
            return result;
        }

        // trả về true nếu có một đường tăng và ngược lại
        boolean bfs() {

            // một hàng đợi số nguyên
            Queue<Integer> Q = new LinkedList<>();

            // Lớp đỉnh đầu tiên đặt khoảng cách là 0
            for (int u = 1; u <= m; u++) {

                // Nếu nó là một đỉnh tự do thêm nó vào hàng đợi
                if (pairU[u] == NIL) {

                    // u chưa được matched
                    dist[u] = 0;
                    Q.add(u);
                }

                // ngược lại đặt khoảng cách là vô cực để xét đỉnh này ở lần tiếp theo
                else
                    dist[u] = INF;
            }

            // khởi tạo khoảng cách tới NIL là vô cực
            dist[NIL] = INF;

            // Q sẽ chỉ chứa các đỉnh ở phía bên trái
            while (!Q.isEmpty()) {

                // Xóa một đỉnh
                int u = Q.poll();

                // Nếu node này không phải là NIL và khoảng cách nhỏ hơn NIL
                if (dist[u] < dist[NIL]) {

                    // Lấy tất cả các đỉnh kề với đỉnh u bị xóa (dequeued vertex u)
                    for (int i : adj.get(u)) {
                        int v = i;

                        // Nếu ghép cặp của v là chưa được xét thì (v, pairV[v]) cũng là cạnh chưa
                        // được khám phá.
                        if (dist[pairV[v]] == INF) {

                            // xét ghép cặp và thêm nó vào hàng đợi
                            dist[pairV[v]] = dist[u] + 1;
                            Q.add(pairV[v]);
                        }
                    }
                }
            }

            // Nếu chúng ta có thể quay lại NIL bằng cách sử dụng đường pha của
            // các đỉnh khác nhau thì có một đường tăng
            return (dist[NIL] != INF);
        }

        // Trả về true nếu có một đường tăng bắt đầu từ đỉnh u
        boolean dfs(int u) {
            if (u != NIL) {
                for (int i : adj.get(u)) {

                    // kề với u
                    int v = i;

                    // thiết lập khoảng cách bởi BFS
                    if (dist[pairV[v]] == dist[u] + 1) {

                        // Nếu DFS [ghép cặp của v] cũng trả về
                        // true
                        if (dfs(pairV[v]) == true) {
                            pairV[v] = u;
                            pairU[u] = v;
                            return true;
                        }
                    }
                }

                // Nếu không có đường tăng bắt đầu từ đỉnh u
                dist[u] = INF;
                return false;
            }
            return true;
        }

        // Khởi tạo
        @SuppressWarnings("unchecked")
        public BipGraph(int m, int n) {
            this.m = m;
            this.n = n;
            adj = new ArrayList<ArrayList<Integer>>();
            for (int i = 0; i <= m; i++) {
                adj.add(new ArrayList<>());
            }
        }

        // Để thêm cạnh từ u đến v và từ v đến u
        void addEdge(int u, int v) {
            // thêm v vào danh sách kề của u
            adj.get(u).add(v);
        }
    }

    // Driver code
    public static void main(String[] args) {

        BipGraph g = new BipGraph(4, 4);
        g.addEdge(1, 1);
        g.addEdge(1, 2);
        g.addEdge(1, 4);
        g.addEdge(2, 1);
        g.addEdge(3, 2);
        g.addEdge(4, 1);
        g.addEdge(4, 2);
        g.addEdge(4, 3);
        g.addEdge(4, 4);

        System.out.println("Size of maximum matching is " + g.hopcroftKarp());
    }
}