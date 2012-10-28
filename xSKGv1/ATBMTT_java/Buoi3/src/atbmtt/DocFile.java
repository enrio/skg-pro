package atbmtt;

public class DocFile {
	public static void main(String[] args) {
		try {
			FileHasher x = new FileHasher();

			// Tạo MD5 từ chuỗi, lưu vào file
			String msg = "Khong co gi qui hon doc lap tu do thiet khong?";
			x.CreateFileMD5("c:\\toan.txt", msg);

			// Tạo MD5 cho file
			byte[] t = x.ReadFileMD5("c:\\toan.iso");
			for (int i = 0; i < t.length; i++)
				System.out.print(String.format("%X", t[i]) + " ");

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
