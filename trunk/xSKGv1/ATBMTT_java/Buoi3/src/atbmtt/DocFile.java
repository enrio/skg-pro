package atbmtt;

public class DocFile {
	public static void main(String[] args) {
		try {
			FileHasher x = new FileHasher();

			// Tạo MD5 từ chuỗi, lưu vào file
			String msg = "Khong co gi qui hon doc lap tu do thiet khong?";
			x.CreateFileMD5("c:\\toan.txt", msg);

			// Tạo MD5 cho file
			String check = FileHasher.getMD5Checksum("c:\\toan.iso");
			System.out.print("MD5:   " + check);

			System.out.println();

			// Tạo SHA-1 cho file
			check = FileHasher.getSHAChecksum("c:\\toan.iso");
			System.out.print("SHA-1: " + check);

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
