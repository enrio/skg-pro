package atbmtt;

import java.util.Scanner;

public class Nhap_Matkhau {
	public static void main(String[] args) {
		try {
			// Nhập mật khẩu
			Scanner userIn = new Scanner(System.in);
			System.out.print("Mật khẩu: ");
			String msg = userIn.nextLine();
			userIn.close();

			// Tạo MD5 và lưu vào file
			FileHasher x = new FileHasher();
			x.CreateFileMD5("c:\\password.txt", msg);

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
