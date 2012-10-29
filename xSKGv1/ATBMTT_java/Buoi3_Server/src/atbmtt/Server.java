package atbmtt;

import java.io.*;
import java.net.*;
import java.security.*;
import java.security.interfaces.*;
import java.security.spec.X509EncodedKeySpec;

import javax.crypto.Cipher;

public class Server {
	public static void main(String[] args) {
		try {
			// Sinh ngẫu nhiên 1 cặp khoá
			KeyPairGenerator gen = KeyPairGenerator.getInstance("RSA");
			KeyPair key = gen.generateKeyPair();

			// Tạo khoá công khai kp, khoá bí mật ks
			RSAPublicKey kp_Server = (RSAPublicKey) key.getPublic();
			RSAPrivateKey ks_Server = (RSAPrivateKey) key.getPrivate();

			// 1. tao server socket lang nghe tren cong 3333
			ServerSocket ss = new ServerSocket(3333);

			System.out.println("Server đang lắng nghe trên cổng 3333...");
			while (true) {
				// 2. Chờ client kết nối đến
				Socket s = ss.accept();
				System.out.println("Thêm một client kết nối đến.");

				// 3. Lấy InputStream và OutputStream từ Socket s
				InputStream is = s.getInputStream();
				OutputStream os = s.getOutputStream();

				// Gởi khoá kp_Server cho client
				os.write(kp_Server.getEncoded());

				// Nhận khoá kp_Client từ Client
				byte[] msg = new byte[1000];
				int n = is.read(msg);

				// Dựng khoá
				X509EncodedKeySpec spec = new X509EncodedKeySpec(msg);
				KeyFactory keyfac = KeyFactory.getInstance("RSA");
				RSAPublicKey kp_Client = (RSAPublicKey) keyfac
						.generatePublic(spec);

				// Tạo và khởi động Si phơ với khoá công khai kp_Client
				Cipher cp = Cipher.getInstance("RSA");
				cp.init(Cipher.ENCRYPT_MODE, kp_Client);

				// Gởi thông điệp đã mã hoá cho Client
				/*String hello = "Hello Zng Tfy!";
				byte[] cip = cp.doFinal(hello.getBytes());
				os.write(cip);*/
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}